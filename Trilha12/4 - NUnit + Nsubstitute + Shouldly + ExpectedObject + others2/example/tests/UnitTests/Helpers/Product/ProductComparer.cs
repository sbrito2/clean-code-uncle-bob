using System;
using System.Collections;
using System.Collections.Generic;
using api.Models;

namespace TestsHelper
{
    public class ProductComparer : IComparer, IComparer<Product>
    {
        public int Compare(object expected, object actual)
        {
            var lhs = expected as Product;
            var rhs = actual as Product;
            if (lhs == null && rhs == null) return 1;
            if (lhs == null || rhs == null) return 0;
            return Compare(lhs, rhs);
        }

        public int Compare(Product expected, Product actual)
        {
            int temp;
            return (temp = expected.Id.CompareTo(actual.Id)) != 0 ? temp : expected.Name.CompareTo(actual.Name);
        }

        // The example displays the following output:
        // Comparing 16325 and 0: 1 (GreaterThan).
        // Comparing 16325 and 16325: 0 (Equal).
        // Comparing 16325 and -1934: 1 (GreaterThan).
        // Comparing 16325 and 903624: -1 (LessThan).
    }
}
