//using CompulsoryCow.DateTime.Abstractions;
//using FluentAssertions;

//namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
//{
//    internal interface IRepository
//    {
//        int Upsert(User user);
//    }
//    internal interface IUserControl
//    {
//        User Upsert(User user);
//    }

//    internal class UserControl : IUserControl
//    {
//        private readonly IRepository _repository;
//        private readonly IDateTime _datetime;

//        internal UserControl(IRepository repository, IDateTime datetime)
//        {
//            _repository = repository;
//            _datetime = datetime;
//        }
//        public User Upsert(User user)
//        {
//            user.Updated =_datetime.UtcNow;
//            var userId = _repository.Upsert(user);
//            user.Id = userId;
//            return user;
//        }
//    }

//    internal class User
//    {
//        internal int Id { get; set; }
//        internal IDateTime Updated { get; set; }
//    }

//    public void TestExample_ShouldPersistCreatedAsUtcNow()
//    {
//        //  #   Arrange.
//        var anyTime = 1042L;
//        var anyId = 1043;
//        var mockedDateTime = new Moq<IDateTime>();
//        mockedDateTime.Setup(m => m.UtcNow).Returns(new DateTime(anyTime));
//        var mockedRepository = new Moq<IRepository>();
//        mockedRepository.Setup(m => m.Upsert(It.IsAny<User>).Returns(anyId);
//        var sut = new UserControl(mockedRepository.Object, mockedDateTime.Object);

//        //  #   Act.
//        var res = sut.Upsert(new User());

//        //  #   Assert.
//        res.Updated.Should().Be(new DateTime(anyTime));
//    }
//}
