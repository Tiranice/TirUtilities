<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Namespace TirUtilities.External.OdinSerializer.Utilities
   | TirUtilities </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Namespace TirUtilities.External.OdinSerializer.Utilities
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
            <article class="content wrap" id="_content" data-uid="TirUtilities.External.OdinSerializer.Utilities">
  
  <h1 id="TirUtilities_External_OdinSerializer_Utilities" data-uid="TirUtilities.External.OdinSerializer.Utilities" class="text-break">Namespace TirUtilities.External.OdinSerializer.Utilities
  </h1>
  <div class="markdown level0 summary"></div>
  <div class="markdown level0 conceptual"></div>
  <div class="markdown level0 remarks"></div>
    <h3 id="classes">Classes
  </h3>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.Cache-1.html">Cache&lt;T&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.Cache-1.yml" sourcestartlinenumber="2" sourceendlinenumber="8">Provides an easy way of claiming and freeing cached values of any non-abstract reference type with a public parameterless constructor.
<p>
Cached types which implement the <a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ICacheNotificationReceiver.html">ICacheNotificationReceiver</a> interface will receive notifications when they are claimed and freed.
<p>
Only one thread should be holding a given cache instance at a time if <a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ICacheNotificationReceiver.html">ICacheNotificationReceiver</a> is implemented, since the invocation of 
<a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ICacheNotificationReceiver.html#TirUtilities_External_OdinSerializer_Utilities_ICacheNotificationReceiver_OnFreed">OnFreed()</a> is not thread safe, IE, weird stuff might happen if multiple different threads are trying to free
the same cache instance at the same time. This will practically never happen unless you&apos;re doing really strange stuff, but the case is documented here.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.DoubleLookupDictionary-3.html">DoubleLookupDictionary&lt;TFirstKey, TSecondKey, TValue&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.DoubleLookupDictionary-3.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.EmitUtilities.html">EmitUtilities</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.EmitUtilities.yml" sourcestartlinenumber="2" sourceendlinenumber="4">Provides utilities for using the <a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.emit">System.Reflection.Emit</a> namespace.
<p>
This class is due for refactoring. Use at your own peril.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.FastTypeComparer.html">FastTypeComparer</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.FastTypeComparer.yml" sourcestartlinenumber="2" sourceendlinenumber="3">Compares types by reference before comparing them using the default type equality operator.
This can constitute a <em>significant</em> speedup when used as the comparer for dictionaries.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.FieldInfoExtensions.html">FieldInfoExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.FieldInfoExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">FieldInfo method extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.Flags.html">Flags</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.Flags.yml" sourcestartlinenumber="2" sourceendlinenumber="2">This class encapsulates common <a class="xref" href="https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags">BindingFlags</a> combinations.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.html">GarbageFreeIterators</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Garbage free enumerator methods.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ImmutableList.html">ImmutableList</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ImmutableList.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Immutable list wraps another list, and allows for reading the inner list, without the ability to change it.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ImmutableList-1.html">ImmutableList&lt;T&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ImmutableList-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ImmutableList-2.html">ImmutableList&lt;TList, TElement&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ImmutableList-2.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Immutable list wraps another list, and allows for reading the inner list, without the ability to change it.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.LinqExtensions.html">LinqExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.LinqExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Various LinQ extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MemberAliasFieldInfo.html">MemberAliasFieldInfo</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasFieldInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="4">Provides a methods of representing imaginary fields which are unique to serialization.
<p>
We aggregate the FieldInfo associated with this member and return a mangled form of the name.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.html">MemberAliasMethodInfo</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasMethodInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="7">Provides a methods of representing aliased methods.
<p>
In this case, what we&apos;re representing is a method on a parent class with the same name.
<p>
We aggregate the MethodInfo associated with this member and return a mangled form of the name.
The name that we return is &quot;parentname+methodName&quot;.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MemberAliasPropertyInfo.html">MemberAliasPropertyInfo</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberAliasPropertyInfo.yml" sourcestartlinenumber="2" sourceendlinenumber="4">Provides a methods of representing imaginary properties which are unique to serialization.
<p>
We aggregate the PropertyInfo associated with this member and return a mangled form of the name.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MemberInfoExtensions.html">MemberInfoExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MemberInfoExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">MemberInfo method extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.MethodInfoExtensions.html">MethodInfoExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.MethodInfoExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Various extensions for MethodInfo.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.PathUtilities.html">PathUtilities</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.PathUtilities.yml" sourcestartlinenumber="2" sourceendlinenumber="2">DirectoryInfo method extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.PropertyInfoExtensions.html">PropertyInfoExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.PropertyInfoExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">PropertyInfo method extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ReferenceEqualityComparer-1.html">ReferenceEqualityComparer&lt;T&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ReferenceEqualityComparer-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Compares objects by reference only, ignoring equality operators completely. This is used by the property tree reference dictionaries to keep track of references.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.StringExtensions.html">StringExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.StringExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">String method extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.TypeExtensions.html">TypeExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.TypeExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Type method extensions.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.UnityExtensions.html">UnityExtensions</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.UnityExtensions.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Extends various Unity classes.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.UnityVersion.html">UnityVersion</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.UnityVersion.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Utility class indicating current Unity version.</p>
</section>
    <h3 id="structs">Structs
  </h3>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.DictionaryIterator-2.html">GarbageFreeIterators.DictionaryIterator&lt;T1, T2&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.DictionaryIterator-2.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Dictionary iterator.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.DictionaryValueIterator-2.html">GarbageFreeIterators.DictionaryValueIterator&lt;T1, T2&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.DictionaryValueIterator-2.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Dictionary value iterator.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.HashsetIterator-1.html">GarbageFreeIterators.HashsetIterator&lt;T&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.HashsetIterator-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Hashset iterator.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.ListIterator-1.html">GarbageFreeIterators.ListIterator&lt;T&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.GarbageFreeIterators.ListIterator-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">List iterator.</p>
</section>
    <h3 id="interfaces">Interfaces
  </h3>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ICache.html">ICache</a></h4>
      <section></section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ICacheNotificationReceiver.html">ICacheNotificationReceiver</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ICacheNotificationReceiver.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Provides notification callbacks for values that are cached using the <a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.Cache-1.html">Cache&lt;T&gt;</a> class.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.IImmutableList.html">IImmutableList</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.IImmutableList.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Interface for immutable list.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.IImmutableList-1.html">IImmutableList&lt;T&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.IImmutableList-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Interface for generic immutable list.</p>
</section>
    <h3 id="enums">Enums
  </h3>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.Operator.html">Operator</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.Operator.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Determines the type of operator.</p>
</section>
    <h3 id="delegates">Delegates
  </h3>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.EmitUtilities.InstanceRefMethodCaller-1.html">EmitUtilities.InstanceRefMethodCaller&lt;InstanceType&gt;</a></h4>
      <section></section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.EmitUtilities.InstanceRefMethodCaller-2.html">EmitUtilities.InstanceRefMethodCaller&lt;InstanceType, TArg1&gt;</a></h4>
      <section></section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ValueGetter-2.html">ValueGetter&lt;InstanceType, FieldType&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ValueGetter-2.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.ValueSetter-2.html">ValueSetter&lt;InstanceType, FieldType&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.ValueSetter-2.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.WeakValueGetter.html">WeakValueGetter</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.WeakValueGetter.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.WeakValueGetter-1.html">WeakValueGetter&lt;FieldType&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.WeakValueGetter-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.WeakValueSetter.html">WeakValueSetter</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.WeakValueSetter.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
      <h4><a class="xref" href="TirUtilities.External.OdinSerializer.Utilities.WeakValueSetter-1.html">WeakValueSetter&lt;FieldType&gt;</a></h4>
      <section><p sourcefile="api/TirUtilities.External.OdinSerializer.Utilities.WeakValueSetter-1.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Not yet documented.</p>
</section>
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
