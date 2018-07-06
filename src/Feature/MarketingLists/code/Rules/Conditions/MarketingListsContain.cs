using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.DataExchange.Tools.DynamicsConnect.Facets;
using Sitecore.Framework.Rules;
using Sitecore.XConnect;
using Sitecore.XConnect.Segmentation.Predicates;

namespace Feature.MarketingLists.Rules.Conditions
{
    public class MarketingListsContain : ICondition,  IContactSearchQueryFactory
    {
        public string listId
        {
            get;
            set;
        }

        public string Comparison { get; set; }

        public MarketingListsContain()
        {
        }

        public Expression<Func<Contact, bool>> CreateContactSearchQuery(IContactSearchQueryContext context)
        {
            Expression<Func<Contact, bool>> expression = (Contact contact) => contact.GetFacet<DynamicsMembership>("DynamicsMembership").MarketingListIds.Any<string>((string id) => id == this.listId);
            return expression;
        }

        public bool Evaluate(IRuleExecutionContext context)
        {
            bool flag;
            Contact contact = context.Fact<Contact>(null);
            if (contact != null)
            {
                DynamicsMembership facet = contact.GetFacet<DynamicsMembership>("DynamicsMembership");
                flag = facet.MarketingListIds.Contains(this.listId);
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}