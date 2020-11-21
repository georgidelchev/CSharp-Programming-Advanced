using System;
using System.Collections.Generic;
using System.Text;
using Component.Models;

namespace Component.Contracts
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift);
    }
}
