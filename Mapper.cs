using System.Reflection;

namespace MapperConfiguration
{

    /// <summary>
    /// The static mapper class.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Use this method to convert you're source DTO to target DTO.
        /// </summary>
        /// <typeparam name="T">The output type</typeparam>
        /// <typeparam name="R">The input type</typeparam>
        /// <param name="objectToMap">The objectToMap.</param>
        /// <returns>Returns the converted output DTO.</returns>
        public static T MapTo<T, R>(R objectToMap)
                      where T : new()
                      where R : class
        {
            var newInstance = new T();
            if (objectToMap != null)
            {
                var sourceType = typeof(R);
                foreach (var item in newInstance.GetType().GetProperties())
                {
                    var sourceProperty = sourceType.GetProperty(item.Name);
                    if (sourceProperty != null && sourceProperty.PropertyType == item.PropertyType)
                    {
                        item.SetValue(newInstance, sourceProperty.GetValue(objectToMap));
                    }

                }
            }

            return newInstance;
        }
    }
}
