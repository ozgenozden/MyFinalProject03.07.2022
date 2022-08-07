using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint :generic kısıtı 
    //T değeri bir referans tip olabilir(class diyerek bunu sağlamış olduk), ve
    //IEntity den implamant olmuş bir nesne olmalıdır.
    public interface IEntityRepository<T> where T :class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId); Bu koda ihtiyacımız kalmadı çünkü bunu karşılayan GetAll veya
        //Get() metotlarında expressipn filter kullanarak bunu da kapsamı olduk.
    }
}
