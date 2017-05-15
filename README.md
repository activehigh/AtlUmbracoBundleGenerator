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

EXAMPLE:
========
Add scripts the way you like. Example - 

[https://drive.google.com/open?id=0BxlGwvpYVcYMU2Y4ODZEQzlRRFU](https://drive.google.com/open?id=0BxlGwvpYVcYMU2Y4ODZEQzlRRFU)

Include the namespace in your template - 

[https://drive.google.com/open?id=0BxlGwvpYVcYMMjN0LWxXVE9QczA](https://drive.google.com/open?id=0BxlGwvpYVcYMMjN0LWxXVE9QczA)

Render minified files - 

[https://drive.google.com/open?id=0BxlGwvpYVcYMckhWamd6ZEJVZUE](https://drive.google.com/open?id=0BxlGwvpYVcYMckhWamd6ZEJVZUE)
