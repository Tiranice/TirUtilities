<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class TabGroup
   | TirUtilities </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class TabGroup
   | TirUtilities ">
    <meta name="generator" content="docfx 2.56.6.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    <meta property="docfx:rel" content="../">
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div class="container body-content">
        
        <div id="search-results">
          <div class="search-list">Search Results for <span></span></div>
          <div class="sr-items">
            <p><i class="glyphicon glyphicon-refresh index-loading"></i></p>
          </div>
          <ul id="pagination" data-first="First" data-prev="Previous" data-next="Next" data-last="Last"></ul>
        </div>
      </div>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="TirUtilities.UI.TabGroup">
  
  
  <h1 id="TirUtilities_UI_TabGroup" data-uid="TirUtilities.UI.TabGroup" class="text-break">Class TabGroup
  </h1>
  <div class="markdown level0 summary"><p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Derived from code written by Matt Gambell <a href="https://youtu.be/211t6r12XPQ" data-raw-source="https://youtu.be/211t6r12XPQ" sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">https://youtu.be/211t6r12XPQ</a></p>
<p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="4" sourceendlinenumber="4">Maintains all tabs in child objects.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a></div>
    <div class="level1"><span class="xref">TabGroup</span></div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="TirUtilities.UI.html">TirUtilities.UI</a></h6>
  <h6><strong>Assembly</strong>: cs.temp.dll.dll</h6>
  <h5 id="TirUtilities_UI_TabGroup_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class TabGroup : MonoBehaviour</code></pre>
  </div>
  <h3 id="fields">Fields
  </h3>
  
  
  <h4 id="TirUtilities_UI_TabGroup_tabButtons" data-uid="TirUtilities.UI.TabGroup.tabButtons">tabButtons</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;TabButton&gt; tabButtons</code></pre>
  </div>
  <h5 class="fieldValue">Field Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">List</span>&lt;<a class="xref" href="TirUtilities.UI.TabButton.html">TabButton</a>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TirUtilities_UI_TabGroup_OnTabEnter_" data-uid="TirUtilities.UI.TabGroup.OnTabEnter*"></a>
  <h4 id="TirUtilities_UI_TabGroup_OnTabEnter_TirUtilities_UI_TabButton_" data-uid="TirUtilities.UI.TabGroup.OnTabEnter(TirUtilities.UI.TabButton)">OnTabEnter(TabButton)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Call when the mouse hovers over a tab.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public void OnTabEnter(TabButton button)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="TirUtilities.UI.TabButton.html">TabButton</a></td>
        <td><span class="parametername">button</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TirUtilities_UI_TabGroup_OnTabExit_" data-uid="TirUtilities.UI.TabGroup.OnTabExit*"></a>
  <h4 id="TirUtilities_UI_TabGroup_OnTabExit" data-uid="TirUtilities.UI.TabGroup.OnTabExit">OnTabExit()</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Call when a tab is deselected or the mouse leaves the tab.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public void OnTabExit()</code></pre>
  </div>
  
  
  <a id="TirUtilities_UI_TabGroup_OnTabSelected_" data-uid="TirUtilities.UI.TabGroup.OnTabSelected*"></a>
  <h4 id="TirUtilities_UI_TabGroup_OnTabSelected_TirUtilities_UI_TabButton_" data-uid="TirUtilities.UI.TabGroup.OnTabSelected(TirUtilities.UI.TabButton)">OnTabSelected(TabButton)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Call when a tab is selected.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public void OnTabSelected(TabButton button)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="TirUtilities.UI.TabButton.html">TabButton</a></td>
        <td><span class="parametername">button</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TirUtilities_UI_TabGroup_ResetTabs_" data-uid="TirUtilities.UI.TabGroup.ResetTabs*"></a>
  <h4 id="TirUtilities_UI_TabGroup_ResetTabs" data-uid="TirUtilities.UI.TabGroup.ResetTabs">ResetTabs()</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Call to reset all tabs to their default state.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public void ResetTabs()</code></pre>
  </div>
  
  
  <a id="TirUtilities_UI_TabGroup_Subscribe_" data-uid="TirUtilities.UI.TabGroup.Subscribe*"></a>
  <h4 id="TirUtilities_UI_TabGroup_Subscribe_TirUtilities_UI_TabButton_" data-uid="TirUtilities.UI.TabGroup.Subscribe(TirUtilities.UI.TabButton)">Subscribe(TabButton)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.UI.TabGroup.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Adds a button the the list of buttons managed by the tab group.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public void Subscribe(TabButton button)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="TirUtilities.UI.TabButton.html">TabButton</a></td>
        <td><span class="parametername">button</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            TirUtilities
            
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>