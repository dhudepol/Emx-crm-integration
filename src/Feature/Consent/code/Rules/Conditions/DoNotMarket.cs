using System;
using System.Linq.Expressions;
using Sitecore.Framework.Rules;
using Sitecore.XConnect;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Segmentation.Predicates;

namespace Feature.Consent.Rules.Conditions
{
    public class DoNotMarket : ICondition, IContactSearchQueryFactory
    {

        public string Comparison { get; set; }

        public DoNotMarket()
        {
        }

        public Expression<Func<Contact, bool>> CreateContactSearchQuery(IContactSearchQueryContext context)
        {
            Expression<Func<Contact, bool>> expression = (Contact contact) =>
                contact.ConsentInformation().ConsentRevoked == true;
            return expression;
        }

        public bool Evaluate(IRuleExecutionContext context)
        {
            bool flag;
            Contact contact = context.Fact<Contact>(null);
            if (contact != null)
            {

                flag = contact.ConsentInformation().ConsentRevoked;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}