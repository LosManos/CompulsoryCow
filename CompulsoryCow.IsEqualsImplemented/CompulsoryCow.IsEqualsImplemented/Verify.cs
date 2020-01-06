using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompulsoryCow.IsEqualsImplemented
{
    public class Verify
    {
        private readonly IList<Type> _ignoredClasses = new List<Type>();

        private readonly Dictionary<Type, Func<object>> _instantiateObjectActions = new Dictionary<Type, Func<object>>();

        private readonly IDictionary<Type, object> _equalValues = new Dictionary<Type, object>
        {
            { typeof(int), 1 },
            { typeof(string), "AA" },
            { typeof(char), 'C' },
            { typeof(long), 11 },
            { typeof(float), 1.1f },
            { typeof(double), 1.11d }
        };

        private readonly IDictionary<Type, object> _differingValues = new Dictionary<Type, object>
        {
            { typeof(int), 2 },
            { typeof(string), "BB" },
            { typeof(char) ,'D' },
            { typeof(long), 11 },
            { typeof(float), 1.2f },
            { typeof(double), 1.22d }
        };

        /// <summary>This property contains the Type of the class that does not have Equals implemented correctly.
        /// Updated every time <see cref="AreAllEqualsImplementedCorrectly(Assembly){T}"/> is called.
        /// </summary>
        public Type ResultClass { get; private set; }
        
        /// <summary>This property contains a friendly message about which property was not used in the Equals comparison. 
        /// Updated every time <see cref="IsEqualsImplementedCorrectly{T}"/> or <see cref="AreAllEqualsImplementedCorrectly(Assembly)"/> is called.
        /// If last check returned true this property is null.
        /// </summary>
        public string ResultMessage { get; private set; }

        /// <summary>This property contains the <see cref="PropertyInfo"/> for the property that was not in the Equals comparison.
        /// Updated every time <see cref="IsEqualsImplementedCorrectly{T}"/> is called.
        /// If last check returned true this property is null.
        /// </summary>
        public PropertyInfo ResultProperty { get; private set; }

        /// <summary>This method is used for verifying classes 
        /// that do not have a default constructor.
        /// Call it before verifying the class.
        /// </summary>
        /// <param name="instantiateObjectAction"></param>
        /// <example>
        /// verify.AddInstantiator(() => new Customer("myName"))
        /// </example>
        public void AddInstantiator<T>(Func<object> instantiateObjectAction)
        {
            _instantiateObjectActions.Add(
                typeof(T),
                instantiateObjectAction);
        }

        /// <summary>This method is used for exclude classes from comparison test.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AddIgnoredClass<T>()
        {
            _ignoredClasses.Add(typeof(T));
        }

        /// <summary>This method goes through an assembly and finds all classes with Equals explicitly implemented. See <see cref="IsEqualsImplementedCorrectly{T}"/> for how the check is done.
        /// True is returned if everything looks ok.
        /// Otherwise False is returned and <see cref="ResultClass"/> and <see cref="ResultMessage"/> are updated.
        /// 
        /// If a class should not be checked for, add the the type through <see cref="AddIgnoredClass{T}"/>.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public bool AreAllEqualsImplementedCorrectly(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));

            IEnumerable<Type> GetAllClassesIn(Assembly a) =>
                a.GetTypes()
                .Where(classType => _ignoredClasses.Contains(classType) == false)
                .Where(classType => HasEqualsBeenDeclared(classType));

            bool Return(Type resultClass, string resultMessage, bool result)
            {
                ResultClass = resultClass;
                ResultMessage = resultMessage;
                return result;
            }

            bool ReturnSuccess(Type resultClass, string resultMessage) =>
                Return(resultClass, resultMessage, true);

            bool ReturnFail(Type resultClass, string resultMessage) =>
                Return(resultClass, resultMessage, false);

            IEnumerable<(Type ClassType, bool IsImplementedCorrectly)> IsImplementedCorrectlyOrNot(IList<Type> classTypes) =>
                classTypes
                .Select(ct => (
                    ClassType: ct, IsImplementedCorrectly:
                    IsEqualsImplementedCorrectly(ct)));

            int CorrectlyImplementedCount(IList<(Type ClassType, bool IsImplementedCorrectly)> implementedClasses) =>
                implementedClasses.Count(ct => ct.IsImplementedCorrectly);

            bool IsAllEqualsImplementedCorrectly(
                IList<Type> allClssDefiningEquals,
                IList<(Type ClassType, bool IsImplementedCorrectly)> implementedClasses) =>
                allClssDefiningEquals.Count() == CorrectlyImplementedCount(implementedClasses);

            Type AnyClassWithFailingImplementation(IList<(Type ClassType, bool IsImplementedCorrectly)> classes) =>
                classes.First(c => c.IsImplementedCorrectly == false).ClassType;

            var allClassesDefiningEquals = GetAllClassesIn(assembly).ToList();

            if( allClassesDefiningEquals.Count() == 0)
            {
                return ReturnSuccess(
                    null, 
                    $"No class in the assembly {assembly.GetName().Name} seems to implement Equals.");
            }

            var allClassesWithEqualsImplementation = IsImplementedCorrectlyOrNot(allClassesDefiningEquals).ToList();

            if( IsAllEqualsImplementedCorrectly( allClassesDefiningEquals, allClassesWithEqualsImplementation))
            {
                return ReturnSuccess(null, null);
            }
            else
            {
                var aClass = AnyClassWithFailingImplementation(allClassesWithEqualsImplementation);
                return ReturnFail(
                    aClass, 
                    $"It seems class {aClass.Name} does not implement Equals correctly.");
            }
        }

        /// <summary>This method returns true if Equals(object) has been explicitly declared for a class.
        /// False is returned otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasEqualsBeenDeclared<T>()
        {
            return HasEqualsBeenDeclared(typeof(T));
        }

        /// <summary>This method checks if the Equals method is implemented correctly.
        /// If Equals seems to be implemented correcxtly True is returned. <see cref="ResultProperty"/> and <see cref="ResultMessage"/> are set to null.
        /// False is returned otherwise and <see cref="ResultProperty"/> and <see cref="ResultMessage"/> are updated with property info and a friendly message respectively.
        /// With "implemented correctly" means that each and every public property is used in the comparison.
        /// 
        /// Technically the comparison is just changing the value of each and every property one, by one, and see if Equals changes return value.
        /// 
        /// If the class in question does not have a default constructor
        /// a method for explicitly instantiating the class has to be provided
        /// through <see cref="AddInstantiator{T}(Func{object})"/>.
        /// 
        /// If the class has a property of a type that is not handled by <see cref="IsEqualsImplemented"/>, 
        /// just call <see cref="SetComparisonValues{T}(T, T)"/> for every such type.
        /// 
        /// Note: It is important to implemented GetHashCode and override == and != but this is not checked for.
        /// 
        /// Note for future: There is no problem implementing a similar method that takes two already instantiated objects.
        /// Creating a method that compares other things than public properties requires a bit more afterthought for making used friendly.
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool IsEqualsImplementedCorrectly<T>()
        {
            return IsEqualsImplementedCorrectly(typeof(T));
        }

        /// <summary>This method shoud be called if the class used by <see cref="IsEqualsImplementedCorrectly{T}"/> contains a type that is not known, for instance a sub class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="equalValue"></param>
        /// <param name="differingValue"></param>
        public void SetComparisonValues<T>(T equalValue, T differingValue)
        {
            _equalValues.Add(typeof(T), equalValue);
            _differingValues.Add(typeof(T), differingValue);
        }

        #region Private helper methods.

        private static object GetDefault(Type type)
        {
            // https://stackoverflow.com/a/353073/521554
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        private static bool HasEqualsBeenDeclared(Type type)
        {
            const string EqualsMethodName = "Equals";

            // https://stackoverflow.com/questions/2932421/detect-if-a-method-was-overridden-using-reflection-c
            return type
                .GetMethod(
                    EqualsMethodName,
                    BindingFlags.ExactBinding | BindingFlags.Public | BindingFlags.Instance,
                    Type.DefaultBinder,
                    new[] { typeof(object) },
                    null
                )
                .DeclaringType == type;
        }

        private bool IsEqualsImplementedCorrectly(Type type)
        {
            // var o1 = new T();
            var o1 = _instantiateObjectActions.ContainsKey(type)?
                _instantiateObjectActions[type]() :
                Activator.CreateInstance(type);
            SetAllPropertiesToEqualValues(o1);

            // var o2 = new T();
            var o2 = _instantiateObjectActions.ContainsKey(type)?
                _instantiateObjectActions[type]():
                Activator.CreateInstance(type);
            foreach (var differingProperty in Meta.GetPublicProperties(o2))
            {
                SetAllPropertiesToEqualValues(o2);
                SetPropertyToDifferingValue(o2, differingProperty);
                if (o1.Equals(o2))
                {
                    ResultMessage = $"It seems property {differingProperty.Name} is not used in the comparison.";
                    ResultProperty = differingProperty;
                    return false;
                }
            }

            ResultMessage = null;
            ResultProperty = null;
            return true;
        }

        private void SetAllPropertiesToEqualValues<T>(T o1) where T : new()
        {
            foreach (var property in Meta.GetPublicProperties(o1))
            {
                SetPropertyToValue(o1, property, _equalValues);
            }
        }

        private void SetPropertyToDifferingValue<T>(T o, PropertyInfo property)
        {
            SetPropertyToValue(o, property, _differingValues);
        }

        private static void SetPropertyToValue<T>(T o, PropertyInfo property, IDictionary<Type, object> values)
        {
            var key = values.Keys.FirstOrDefault(k => k == property.PropertyType);
            if (key == null)
            {
                throw new TypeNotRecognisedException($"The type {property.PropertyType} has no value to test with. Use {nameof(SetComparisonValues)}");
            }

            var value = values[key];

            if (value == null)
            {
                throw new NotImplementedException("TBA:REturn a message should not be null");
            }
            if (value.GetType() != property.PropertyType)
            {
                throw new NotImplementedException("TBA:Should throw an exception describining which cast failed.");
            }
            if (value == GetDefault(property.PropertyType))
            {
                throw new NotImplementedException("TBA:Tell a default value is not a good randomised value");
            }
            property.SetValue(o, value);
        }

        #endregion
    }
}
