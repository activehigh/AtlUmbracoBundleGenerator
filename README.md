# AtlUmbracoBundleGenerator

This is bundle minifier for Umbraco CMS. 

Step 1:
======
Add javascript files in umbraco backend.


Step2:
=====
Add using statement for namespace - 


    @using AtlUmbracoBundleGenerator.Extensions
    
Step3:
=====
Render minified javascript with - 

    
    @Html.RenderScripts("~/bundles/(packagename)", .... (files / directories))
    

This package will minify the javsascript and render.

For CSS use 

    @Html.RenderStyles("~/bundles/(packagename)", .... (files / directories))
