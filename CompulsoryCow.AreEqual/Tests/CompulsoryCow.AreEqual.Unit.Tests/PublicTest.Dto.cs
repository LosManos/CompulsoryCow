using System;
using VacheTacheLibrary;

namespace AreEqualTest
{
    public partial class PublicTest
	{
        public class Dto
		{
			private string _myPrivate;
			internal string _myInternal;
			protected string _myProtected;
			public string MyPublicString { get; set; }
			public int MyPublicInt { get; set; }

			private Dto(string myPrivate, string myInternal, string myProtected, string myPublicString, int myPublicInt)
			{
				_myPrivate = myPrivate;
				_myInternal = myInternal;
				_myProtected = myProtected;
				MyPublicString = myPublicString;
				MyPublicInt = myPublicInt;	
			}

			internal static Dto CreateSetAllProperties(string myPrivate, string myInternal, string myProtected, string myPublicString, int myPublicInt)
			{
				return new Dto(myPrivate, myInternal, myProtected, myPublicString, myPublicInt);
			}

			internal static Dto CreateRandomised(PseudoRandom pr)
			{
				return CreateSetAllProperties(pr.String(), pr.String(), pr.String(), pr.String(), pr.Int());
			}

			internal Dto FullCopy()
			{
				return CreateSetAllProperties(_myPrivate, _myInternal, _myProtected, MyPublicString, MyPublicInt);
			}

			internal Dto WithRandomisedNonPublic(PseudoRandom pr)
			{
				return SetNonPublic(pr.String(), pr.String(), pr.String());
			}

			internal Dto With(Action<Dto> a)
			{
				a(this);
				return this;
			}

			private Dto SetNonPublic(string myPrivate, string myInternal, string myProtected)
			{
				_myPrivate = myPrivate;
				_myInternal = myInternal;
				_myProtected = myProtected;
				return this;
			}
		}
	}
}
