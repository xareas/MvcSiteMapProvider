﻿using System;
using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider.Visitor;

namespace MvcSiteMapProvider.Builder
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class VisitingSiteMapBuilder
        : ISiteMapBuilder
    {
        public VisitingSiteMapBuilder(
            ISiteMapNodeVisitor siteMapNodeVisitor
            )
        {
            if (siteMapNodeVisitor == null)
                throw new ArgumentNullException("siteMapNodeVisitor");

            this.siteMapNodeVisitor = siteMapNodeVisitor;
        }

        protected readonly ISiteMapNodeVisitor siteMapNodeVisitor;


        #region ISiteMapBuilder Members

        public virtual IEnumerable<string> GetDependencyFileNames()
        {
            return new string[] { };
        }

        public virtual ISiteMapNode BuildSiteMap(ISiteMap siteMap, ISiteMapNode rootNode)
        {
            if (rootNode == null)
            {
                throw new ArgumentNullException("rootNode", Resources.Messages.VisitingSiteMapBuilderRequiresRootNode);
            }

            VisitNodes(rootNode);
            return rootNode;
        }

        protected virtual void VisitNodes(ISiteMapNode node)
        {
            this.siteMapNodeVisitor.Execute(node);

            if (node.HasChildNodes)
            {
                foreach (var childNode in node.ChildNodes)
                {
                    VisitNodes(childNode);
                }
            }

        }

        #endregion
    }
}