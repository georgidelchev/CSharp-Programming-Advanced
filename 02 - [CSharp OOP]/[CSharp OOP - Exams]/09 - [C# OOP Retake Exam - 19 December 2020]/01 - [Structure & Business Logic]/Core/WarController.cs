using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;

        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            Character character = null;

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name);
                    break;
                case "Priest":
                    character = new Priest(name);
                    break;
                default:
                    var msg = string.Format(ExceptionMessages.InvalidCharacterType, characterType);
                    throw new ArgumentException(msg);
            }

            this.characters.Add(character);
            var outputMsg = string.Format(SuccessMessages.JoinParty, name);
            return outputMsg;
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            Item item = null;
            switch (itemName)
            {
                case "FirePotion":
                    item = new FirePotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                default:
                    var msg = string.Format(ExceptionMessages.InvalidItem, itemName);
                    throw new ArgumentException(msg);
            }

            this.items.Add(item);
            var outputMsg = string.Format(SuccessMessages.AddItemToPool, itemName);
            return outputMsg;
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            if (this.characters.All(c => c.Name != characterName))
            {
                var msg = string.Format(ExceptionMessages.CharacterNotInParty, characterName);
                throw new ArgumentException(msg);
            }

            if (this.items.Count == 0)
            {
                var msg = string.Format(ExceptionMessages.ItemPoolEmpty);
                throw new InvalidOperationException(msg);
            }

            var character = this.characters
                .FirstOrDefault(c => c.Name == characterName);

            var item = this.items[^1];

            character.Bag.AddItem(item);
            this.items.RemoveAt(this.items.Count - 1);

            var outputMsg = string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
            return outputMsg;
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            if (this.characters.All(c => c.Name != characterName))
            {
                var msg = string.Format(ExceptionMessages.CharacterNotInParty, characterName);
                throw new ArgumentException(msg);
            }

            var character = this.characters
                .FirstOrDefault(c => c.Name == characterName);

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            var outputMsg = string.Format(SuccessMessages.UsedItem, characterName, itemName);
            return outputMsg;
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var character in this.characters
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health))
            {
                var status = character.IsAlive ? "Alive" : "Dead";

                sb.AppendLine(
                    $"{character.Name} - " +
                    $"HP: {character.Health}/{character.BaseHealth}, " +
                    $"AP: {character.Armor}/{character.BaseArmor}, " +
                    $"Status: {status}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            if (this.characters.All(c => c.Name != attackerName))
            {
                var msg = string.Format(ExceptionMessages.CharacterNotInParty, attackerName);
                throw new ArgumentException(msg);
            }

            if (this.characters.All(c => c.Name != receiverName))
            {
                var msg = string.Format(ExceptionMessages.CharacterNotInParty, receiverName);
                throw new ArgumentException(msg);
            }

            if (this.characters.Where(c => c.GetType().Name == nameof(Warrior)).All(c => c.Name != attackerName))
            {
                var msg = string.Format(ExceptionMessages.AttackFail, attackerName);
                throw new ArgumentException(msg);
            }

            var attacker = (Warrior)this.characters
                .Where(c => c.GetType().Name == nameof(Warrior))
                .FirstOrDefault(c => c.Name == attackerName);

            var receiver = this.characters
                .FirstOrDefault(c => c.Name == receiverName);

            attacker.Attack(receiver);

            var outputMsg = $"{attackerName} attacks {receiverName} " +
                            $"for {attacker.AbilityPoints} hit points! " +
                            $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP " +
                            $"and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                outputMsg += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return outputMsg;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            if (this.characters.All(c => c.Name != healerName))
            {
                var msg = string.Format(ExceptionMessages.CharacterNotInParty, healerName);
                throw new ArgumentException(msg);
            }

            if (this.characters.All(c => c.Name != healingReceiverName))
            {
                var msg = string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName);
                throw new ArgumentException(msg);
            }

            if (this.characters.Where(c => c.GetType().Name == nameof(Priest)).All(c => c.Name != healerName))
            {
                var msg = string.Format(ExceptionMessages.HealerCannotHeal, healerName);
                throw new ArgumentException(msg);
            }

            var healer = (Priest)this.characters
                .Where(c => c.GetType().Name == nameof(Priest))
                .FirstOrDefault(c => c.Name == healerName);

            var receiver = this.characters
                .FirstOrDefault(c => c.Name == healingReceiverName);

            healer.Heal(receiver);

            var outputMsg = $"{healer.Name} heals {receiver.Name} " +
                            $"for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return outputMsg;
        }
    }
}
