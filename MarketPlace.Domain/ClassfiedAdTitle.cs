using System;
using MarketPlace.Framework;

namespace MarketPlace.Domain {
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle> {
        public static ClassifiedAdTitle FromString (string title) => new ClassifiedAdTitle (title);
        private readonly string _value;

        private ClassifiedAdTitle (string value) {
            if (value.Length > 100) {
                throw new ArgumentException ("Title cannot be longer than 100 chars", nameof (value));
            }
            _value = value;
        }
    }
}