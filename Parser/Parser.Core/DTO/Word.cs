using System;

namespace Parser.Core.DTO
{
    /// <summary>
    /// Represents a single word with number of occurences
    /// </summary>
    public readonly struct Word : IEquatable<Word>
    {
        public readonly string Name;
        public readonly int Counter;
        public Word(string Name, int Counter)
        {
            this.Name = Name;
            this.Counter = Counter;
        }

        public bool Equals(Word other) => other.Name == Name && other.Counter == Counter;
        public override bool Equals(object obj) => obj is Word other ? Equals(other) : false;
        public override int GetHashCode() => Counter.GetHashCode() + Name.GetHashCode();
    }
}
