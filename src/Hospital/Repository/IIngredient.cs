using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository
{
    interface IIngredient: IGenericRepository<IIngredient, int>
    {
    }
}
