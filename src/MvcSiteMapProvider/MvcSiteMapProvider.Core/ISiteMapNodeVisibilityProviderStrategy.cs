﻿using System;
using System.Collections.Generic;
using System.Web;

namespace MvcSiteMapProvider.Core
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface ISiteMapNodeVisibilityProviderStrategy
    {
        ISiteMapNodeVisibilityProvider GetProvider(string providerName);

        /// <summary>
        /// Determines whether the node is visible.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="sourceMetadata">The source metadata.</param>
        /// <returns>
        /// 	<c>true</c> if the specified node is visible; otherwise, <c>false</c>.
        /// </returns>
        bool IsVisible(string providerName, ISiteMapNode node, IDictionary<string, object> sourceMetadata);
    }
}