using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DevFramework.Core.Utilities.Mapper
{
   public  class AutoMapperHelper
    {
        /// <summary>
        /// Generic olarak gelen bir entity list map leyip aynı türde olacak şekilde geri dondurur
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {

            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });
            List<T> result = AutoMapper.Mapper.Map<List<T>, List<T>>(list);
            return result;
        }


        public static T MapToSameType<T>(T entity)
        {

            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });
            T result = AutoMapper.Mapper.Map<T, T>(entity);
            return result;
        }
    }
}
