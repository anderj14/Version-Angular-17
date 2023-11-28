
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ModelWithBrandSpecification : BaseSpecification<Model>
    {
        public ModelWithBrandSpecification()
        {
            AddInclude(v => v.Brand);
        }

        public ModelWithBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(v => v.Brand);
        }
    }
}