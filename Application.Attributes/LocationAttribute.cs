using System;
using System.Collections.Generic;

namespace Application.Attributes
{

    [AttributeUsage(AttributeTargets.Method)]
    public class LocationAttribute : Attribute
    {
        private Dictionary<int, int> translatableLocations;

        public LocationAttribute()
        {
            // we can add here a mapper to translate ids, or it could come from application configuration
            translatableLocations = new Dictionary<int, int>() {
                { 2, 1 }
            };
        }

        /// <summary>
        /// Translate a location ID to another location ID contained in mapper, or return original if not found
        /// </summary>
        /// <param name="originalLocationId"></param>
        /// <returns></returns>
        public virtual int Translate(int originalLocationId)
        {
            if (!translatableLocations.TryGetValue(originalLocationId, out int translatedLocationId))
            {
                return originalLocationId;
            }

            return translatedLocationId;
        }

    }
}
