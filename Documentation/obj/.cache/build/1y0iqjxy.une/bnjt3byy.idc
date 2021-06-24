<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class MemberAliasMethodInfo
   | TirUtilities </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class MemberAliasMethodInfo
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
            <article class="content wrap" id="_content" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo">
  
  
  <h1 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo" class="text-break">Class MemberAliasMethodInfo
  </h1>
  <div class="markdown level0 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="7">Provides a methods of representing aliased methods.
<p>
In this case, what we&apos;re representing is a method on a parent class with the same name.
<p>
We aggregate the MethodInfo associated with this member and return a mangled form of the name.
The name that we return is &quot;parentname+methodName&quot;.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a></div>
    <div class="level1"><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo">MemberInfo</a></div>
    <div class="level2"><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodbase">MethodBase</a></div>
    <div class="level3"><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo">MethodInfo</a></div>
    <div class="level4"><span class="xref">MemberAliasMethodInfo</span></div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.html">TirUtilities.External.OdinSerializer.Utilities</a></h6>
  <h6><strong>Assembly</strong>: cs.temp.dll.dll</h6>
  <h5 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public sealed class MemberAliasMethodInfo : MethodInfo, ICustomAttributeProvider, _MemberInfo, _MethodBase, _MethodInfo</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo__ctor_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.#ctor*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo__ctor_System_Reflection_MethodInfo_System_String_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.#ctor(System.Reflection.MethodInfo,System.String)">MemberAliasMethodInfo(MethodInfo, String)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Initializes a new instance of the <a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.html">MemberAliasMethodInfo</a> class.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public MemberAliasMethodInfo(MethodInfo method, string namePrefix)</code></pre>
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
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo">MethodInfo</a></td>
        <td><span class="parametername">method</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The method to alias.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.string">String</a></td>
        <td><span class="parametername">namePrefix</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The name prefix to use.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo__ctor_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.#ctor*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo__ctor_System_Reflection_MethodInfo_System_String_System_String_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.#ctor(System.Reflection.MethodInfo,System.String,System.String)">MemberAliasMethodInfo(MethodInfo, String, String)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Initializes a new instance of the <a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.html">MemberAliasMethodInfo</a> class.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public MemberAliasMethodInfo(MethodInfo method, string namePrefix, string separatorString)</code></pre>
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
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo">MethodInfo</a></td>
        <td><span class="parametername">method</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The method to alias.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.string">String</a></td>
        <td><span class="parametername">namePrefix</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The name prefix to use.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.string">String</a></td>
        <td><span class="parametername">separatorString</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The separator string to use.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_AliasedMethod_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.AliasedMethod*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_AliasedMethod" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.AliasedMethod">AliasedMethod</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets the aliased method.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public MethodInfo AliasedMethod { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo">MethodInfo</a></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">The aliased method.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_Attributes_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.Attributes*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_Attributes" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.Attributes">Attributes</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets the attributes associated with this method.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override MethodAttributes Attributes { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodattributes">MethodAttributes</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodbase.attributes#System_Reflection_MethodBase_Attributes">MethodBase.Attributes</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_DeclaringType_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.DeclaringType*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_DeclaringType" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.DeclaringType">DeclaringType</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets the class that declares this member.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override Type DeclaringType { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.type">Type</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo.declaringtype#System_Reflection_MemberInfo_DeclaringType">MemberInfo.DeclaringType</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_MethodHandle_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.MethodHandle*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_MethodHandle" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.MethodHandle">MethodHandle</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets a handle to the internal metadata representation of a method.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override RuntimeMethodHandle MethodHandle { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.runtimemethodhandle">RuntimeMethodHandle</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodbase.methodhandle#System_Reflection_MethodBase_MethodHandle">MethodBase.MethodHandle</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_Name_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.Name*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_Name" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.Name">Name</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets the name of the current member.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override string Name { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.string">String</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo.name#System_Reflection_MemberInfo_Name">MemberInfo.Name</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_ReflectedType_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.ReflectedType*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_ReflectedType" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.ReflectedType">ReflectedType</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets the class object that was used to obtain this instance of MemberInfo.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override Type ReflectedType { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.type">Type</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo.reflectedtype#System_Reflection_MemberInfo_ReflectedType">MemberInfo.ReflectedType</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_ReturnType_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.ReturnType*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_ReturnType" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.ReturnType">ReturnType</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override Type ReturnType { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.type">Type</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo.returntype#System_Reflection_MethodInfo_ReturnType">MethodInfo.ReturnType</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_ReturnTypeCustomAttributes_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.ReturnTypeCustomAttributes*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_ReturnTypeCustomAttributes" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.ReturnTypeCustomAttributes">ReturnTypeCustomAttributes</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Gets the custom attributes for the return type.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override ICustomAttributeProvider ReturnTypeCustomAttributes { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.icustomattributeprovider">ICustomAttributeProvider</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo.returntypecustomattributes#System_Reflection_MethodInfo_ReturnTypeCustomAttributes">MethodInfo.ReturnTypeCustomAttributes</a></div>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetBaseDefinition_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetBaseDefinition*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetBaseDefinition" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetBaseDefinition">GetBaseDefinition()</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, returns the MethodInfo object for the method on the direct or indirect base class in which the method represented by this instance was first declared.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override MethodInfo GetBaseDefinition()</code></pre>
  </div>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo">MethodInfo</a></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">A MethodInfo object for the first implementation of this method.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo.getbasedefinition#System_Reflection_MethodInfo_GetBaseDefinition">MethodInfo.GetBaseDefinition()</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetCustomAttributes_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetCustomAttributes*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetCustomAttributes_System_Boolean_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetCustomAttributes(System.Boolean)">GetCustomAttributes(Boolean)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, returns an array of all custom attributes applied to this member.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override object[] GetCustomAttributes(bool inherit)</code></pre>
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
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.boolean">Boolean</a></td>
        <td><span class="parametername">inherit</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">true to search this member&apos;s inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a>[]</td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo.getcustomattributes#System_Reflection_MemberInfo_GetCustomAttributes_System_Boolean_">MemberInfo.GetCustomAttributes(Boolean)</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetCustomAttributes_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetCustomAttributes*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetCustomAttributes_System_Type_System_Boolean_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetCustomAttributes(System.Type,System.Boolean)">GetCustomAttributes(Type, Boolean)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, returns an array of custom attributes applied to this member and identified by <a class="xref" href="https://docs.microsoft.com/dotnet/api/system.type">Type</a>.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override object[] GetCustomAttributes(Type attributeType, bool inherit)</code></pre>
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
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.type">Type</a></td>
        <td><span class="parametername">attributeType</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The type of attribute to search for. Only attributes that are assignable to this type are returned.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.boolean">Boolean</a></td>
        <td><span class="parametername">inherit</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">true to search this member&apos;s inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a>[]</td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">An array of custom attributes applied to this member, or an array with zero elements if no attributes assignable to <code data-dev-comment-type="paramref" class="paramref">attributeType</code> have been applied.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo.getcustomattributes#System_Reflection_MemberInfo_GetCustomAttributes_System_Type_System_Boolean_">MemberInfo.GetCustomAttributes(Type, Boolean)</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetMethodImplementationFlags_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetMethodImplementationFlags*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetMethodImplementationFlags" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetMethodImplementationFlags">GetMethodImplementationFlags()</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, returns the <a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodimplattributes">MethodImplAttributes</a> flags.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override MethodImplAttributes GetMethodImplementationFlags()</code></pre>
  </div>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodimplattributes">MethodImplAttributes</a></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">The MethodImplAttributes flags.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodbase.getmethodimplementationflags#System_Reflection_MethodBase_GetMethodImplementationFlags">MethodBase.GetMethodImplementationFlags()</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetParameters_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetParameters*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_GetParameters" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.GetParameters">GetParameters()</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, gets the parameters of the specified method or constructor.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override ParameterInfo[] GetParameters()</code></pre>
  </div>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.parameterinfo">ParameterInfo</a>[]</td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">An array of type ParameterInfo containing information that matches the signature of the method (or constructor) reflected by this MethodBase instance.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodbase.getparameters#System_Reflection_MethodBase_GetParameters">MethodBase.GetParameters()</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_Invoke_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.Invoke*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_Invoke_System_Object_System_Reflection_BindingFlags_System_Reflection_Binder_System_Object___System_Globalization_CultureInfo_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.Invoke(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)">Invoke(Object, BindingFlags, Binder, Object[], CultureInfo)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, invokes the reflected method or constructor with the given parameters.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)</code></pre>
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
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a></td>
        <td><span class="parametername">obj</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be null or an instance of the class that defines the constructor.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags">BindingFlags</a></td>
        <td><span class="parametername">invokeAttr</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">A bitmask that is a combination of 0 or more bit flags from <a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags">BindingFlags</a>. If <code data-dev-comment-type="paramref" class="paramref">binder</code> is null, this parameter is assigned the value <a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags#System_Reflection_BindingFlags_Default">Default</a>; thus, whatever you pass in is ignored.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.binder">Binder</a></td>
        <td><span class="parametername">binder</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of MemberInfo objects via reflection. If <code data-dev-comment-type="paramref" class="paramref">binder</code> is null, the default binder is used.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a>[]</td>
        <td><span class="parametername">parameters</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, this should be null.If the method or constructor represented by this instance takes a ByRef parameter, there is no special attribute required for that parameter in order to invoke the method or constructor using this function. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is null. For value-type elements, this value is 0, 0.0, or false, depending on the specific element type.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.globalization.cultureinfo">CultureInfo</a></td>
        <td><span class="parametername">culture</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">An instance of CultureInfo used to govern the coercion of types. If this is null, the CultureInfo for the current thread is used. (This is necessary to convert a String that represents 1000 to a Double value, for example, since 1000 is represented differently by different cultures.)</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.object">Object</a></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">An Object containing the return value of the invoked method, or null in the case of a constructor, or null if the method&apos;s return type is void. Before calling the method or constructor, Invoke checks to see if the user has access permission and verifies that the parameters are valid.CautionElements of the <code data-dev-comment-type="paramref" class="paramref">parameters</code> array that represent parameters declared with the ref or out keyword may also be modified.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.methodbase.invoke#System_Reflection_MethodBase_Invoke_System_Object_System_Reflection_BindingFlags_System_Reflection_Binder_System_Object___System_Globalization_CultureInfo_">MethodBase.Invoke(Object, BindingFlags, Binder, Object[], CultureInfo)</a></div>
  
  
  <a id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_IsDefined_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.IsDefined*"></a>
  <h4 id="TirUtilities_External_OdinSerializer_Utilities_MemberAliasMethodInfo_IsDefined_System_Type_System_Boolean_" data-uid="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.IsDefined(System.Type,System.Boolean)">IsDefined(Type, Boolean)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">When overridden in a derived class, indicates whether one or more attributes of the specified type or of its derived types is applied to this member.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public override bool IsDefined(Type attributeType, bool inherit)</code></pre>
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
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.type">Type</a></td>
        <td><span class="parametername">attributeType</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The type of custom attribute to search for. The search includes derived types.</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.boolean">Boolean</a></td>
        <td><span class="parametername">inherit</span></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="1" sourceendlinenumber="1">true to search this member&apos;s inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.boolean">Boolean</a></td>
        <td><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="2">true if one or more instances of <code data-dev-comment-type="paramref" class="paramref">attributeType</code> or any of its derived types is applied to this member; otherwise, false.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="overrides">Overrides</h5>
  <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo.isdefined#System_Reflection_MemberInfo_IsDefined_System_Type_System_Boolean_">MemberInfo.IsDefined(Type, Boolean)</a></div>
  <h3 id="seealso">See Also</h3>
  <div class="seealso">
      <div><a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo">FieldInfo</a></div>
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
