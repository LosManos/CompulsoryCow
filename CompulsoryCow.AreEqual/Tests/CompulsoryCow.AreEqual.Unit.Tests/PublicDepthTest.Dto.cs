using System;
using System.Collections.Generic;
using System.Linq;
using VacheTacheLibrary;

namespace AreEqualTest;

partial class PublicDepthTest
{
    public class Dto
    {
        public int MyProperty { get; set; }
        public Dto Deeper { get; set; }
        internal Dto(int myProperty, Dto deeper)
        {
            MyProperty = myProperty;
            Deeper = deeper;
        }
        internal static Dto Randomise(PseudoRandom pr)
        {
            return new Dto(pr.Int(), null);
        }
        internal enum Pair
        {
            Equal = 1, 
            Differs
        }

        internal static (Dto, Dto) CreatePair(PseudoRandom pr, IEnumerable<Pair> equals)
        {
            var equal = equals.First();
            var equalTail = equals.Skip(1);
            var deeper = equalTail.Any() ?
                CreatePair(pr, equalTail).ToTuple() :
                null;

            var dto = Randomise(pr);
            (Dto, Dto) pair;
            switch (equal)
            {
                case Pair.Equal:
                    pair = (dto, dto.CopyShallow());
                    break;
                case Pair.Differs:
                    pair = (dto, dto.CopyShallow().With(d => d.MyProperty += 1));
                    break;
                default:
                    throw new ArgumentException($"Parameter {nameof(equal)} is not a proper enum.");
            }
            pair.Item1.Deeper = deeper?.Item1;
            pair.Item2.Deeper = deeper?.Item2;

            return pair;
        }

        internal Dto With(Action<Dto> a)
        {
            a(this);
            return this;
        }
        private Dto CopyShallow()
        {
            return new Dto(this.MyProperty, this.Deeper);
        }
    }
}
