<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class PlayingState
   | TirUtilities </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class PlayingState
   | TirUtilities ">
    <meta name="generator" content="docfx 2.58.9.0">
    
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
            <article class="content wrap" id="_content" data-uid="TirUtilities.Experimental.PlayingState">
  
  
  <h1 id="TirUtilities_Experimental_PlayingState" data-uid="TirUtilities.Experimental.PlayingState" class="text-break">Class PlayingState
  </h1>
  <div class="markdown level0 summary"><p sourcefile="api/TirUtilities.Experimental.PlayingState.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Sets the time scale to <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_PausedTimeScale">PausedTimeScale</a>.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a></div>
    <div class="level1"><a class="xref" href="TirUtilities.Experimental.ApplicationState.html">ApplicationState</a></div>
    <div class="level2"><span class="xref">PlayingState</span></div>
  </div>
  <div classs="implements">
    <h5>Implements</h5>
    <div><a class="xref" href="TirUtilities.IState-1.html">IState</a>&lt;<a class="xref" href="TirUtilities.Experimental.ApplicationStateMachine.html">ApplicationStateMachine</a>&gt;</div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState__description">ApplicationState._description</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_Description">ApplicationState.Description</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_PausedTimeScale">ApplicationState.PausedTimeScale</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_PlayingTimeScale">ApplicationState.PlayingTimeScale</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_OnEnterState">ApplicationState.OnEnterState</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_OnExitState">ApplicationState.OnExitState</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_ExitState_TirUtilities_Experimental_ApplicationStateMachine_">ApplicationState.ExitState(ApplicationStateMachine)</a>
    </div>
    <div>
      <a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_UpdateState_TirUtilities_Experimental_ApplicationStateMachine_">ApplicationState.UpdateState(ApplicationStateMachine)</a>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="TirUtilities.Experimental.html">TirUtilities.Experimental</a></h6>
  <h6><strong>Assembly</strong>: cs.temp.dll.dll</h6>
  <h5 id="TirUtilities_Experimental_PlayingState_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public sealed class PlayingState : ApplicationState, IState&lt;ApplicationStateMachine&gt;</code></pre>
  </div>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TirUtilities_Experimental_PlayingState_EnterState_" data-uid="TirUtilities.Experimental.PlayingState.EnterState*"></a>
  <h4 id="TirUtilities_Experimental_PlayingState_EnterState_TirUtilities_Experimental_ApplicationStateMachine_" data-uid="TirUtilities.Experimental.PlayingState.EnterState(TirUtilities.Experimental.ApplicationStateMachine)">EnterState(ApplicationStateMachine)</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override void EnterState(ApplicationStateMachine stateMachine)</code></pre>
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
        <td><a class="xref" href="TirUtilities.Experimental.ApplicationStateMachine.html">ApplicationStateMachine</a></td>
        <td><span class="parametername">stateMachine</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="TirUtilities.Experimental.ApplicationState.html#TirUtilities_Experimental_ApplicationState_EnterState_TirUtilities_Experimental_ApplicationStateMachine_">ApplicationState.EnterState(ApplicationStateMachine)</a></div>
  <h3 id="implements">Implements</h3>
  <div>
      <a class="xref" href="TirUtilities.IState-1.html">IState&lt;T&gt;</a>
  </div>
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