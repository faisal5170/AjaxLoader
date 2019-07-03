Introduction
In this article, we’ll learn how to put AJAX loader for all AJAX calls from all pages which extend from your layout page in MVC. Here, we will create a simple MVC project and call AJAX function from view. For beginners who are new to AJAX, AJAX is Asynchronous JavaScript and XML, it's a front-end web technology that calls web-server asynchronously. It will load your content without loading or leaving your currunt page.

Recommended Prerequisites

Visual Studio 
ASP.NET MVC
Step 1

Open Visual Studio and select “File” >> "New". Then, click on Project.


Step 2

Select “Templates” >> Visual C# >> Web then ASP.NET Web Application (.NET Framework), and put appropriate project name.

And click the “OK” button.
 
Step 3

And, from here select MVC project (you can select the project as per your requirement).

 

Step 4

Now, go to your layout page and put the below code as per the below instruction.

Copy the below CSS, Div, and Script and put in your layout (please see below image for reference).



Loader CSS
<style>  
        /*!  
        // 3. Loader  
        // --------------------------------------------------*/  
        .loader {  
            top: 0;  
            left: 0;  
            position: fixed;  
            opacity: 0.8;  
            z-index: 10000000;  
            background: Black;  
            height: 100%;  
            width: 100%;  
            margin: auto;  
        }  
  
        .strip-holder {  
            top: 50%;  
            -webkit-transform: translateY(-50%);  
            -ms-transform: translateY(-50%);  
            transform: translateY(-50%);  
            left: 50%;  
            margin-left: -50px;  
            position: relative;  
        }  
  
        .strip-1,  
        .strip-2,  
        .strip-3 {  
            width: 20px;  
            height: 20px;  
            background: #0072bc;  
            position: relative;  
            -webkit-animation: stripMove 2s ease infinite alternate;  
            animation: stripMove 2s ease infinite alternate;  
            -moz-animation: stripMove 2s ease infinite alternate;  
        }  
  
        .strip-2 {  
            -webkit-animation-duration: 2.1s;  
            animation-duration: 2.1s;  
            background-color: #23a8ff;  
        }  
  
        .strip-3 {  
            -webkit-animation-duration: 2.2s;  
            animation-duration: 2.2s;  
            background-color: #89d1ff;  
        }  
  
        @@-webkit-keyframes stripMove {  
            0% {  
                transform: translate3d(0px, 0px, 0px);  
                -webkit-transform: translate3d(0px, 0px, 0px);  
                -moz-transform: translate3d(0px, 0px, 0px);  
            }  
  
            50% {  
                transform: translate3d(0px, 0px, 0px);  
                -webkit-transform: translate3d(0px, 0px, 0px);  
                -moz-transform: translate3d(0px, 0px, 0px);  
                transform: scale(4, 1);  
                -webkit-transform: scale(4, 1);  
                -moz-transform: scale(4, 1);  
            }  
  
            100% {  
                transform: translate3d(-50px, 0px, 0px);  
                -webkit-transform: translate3d(-50px, 0px, 0px);  
                -moz-transform: translate3d(-50px, 0px, 0px);  
            }  
        }  
  
        @@-moz-keyframes stripMove {  
            0% {  
                transform: translate3d(-50px, 0px, 0px);  
                -webkit-transform: translate3d(-50px, 0px, 0px);  
                -moz-transform: translate3d(-50px, 0px, 0px);  
            }  
  
            50% {  
                transform: translate3d(0px, 0px, 0px);  
                -webkit-transform: translate3d(0px, 0px, 0px);  
                -moz-transform: translate3d(0px, 0px, 0px);  
                transform: scale(4, 1);  
                -webkit-transform: scale(4, 1);  
                -moz-transform: scale(4, 1);  
            }  
  
            100% {  
                transform: translate3d(50px, 0px, 0px);  
                -webkit-transform: translate3d(50px, 0px, 0px);  
                -moz-transform: translate3d(50px, 0px, 0px);  
            }  
        }  
  
        @@keyframes stripMove {  
            0% {  
                transform: translate3d(-50px, 0px, 0px);  
                -webkit-transform: translate3d(-50px, 0px, 0px);  
                -moz-transform: translate3d(-50px, 0px, 0px);  
            }  
  
            50% {  
                transform: translate3d(0px, 0px, 0px);  
                -webkit-transform: translate3d(0px, 0px, 0px);  
                -moz-transform: translate3d(0px, 0px, 0px);  
                transform: scale(4, 1);  
                -webkit-transform: scale(4, 1);  
                -moz-transform: scale(4, 1);  
            }  
  
            100% {  
                transform: translate3d(50px, 0px, 0px);  
                -webkit-transform: translate3d(50px, 0px, 0px);  
                -moz-transform: translate3d(50px, 0px, 0px);  
            }  
        }  
    </style>  
Loader Div 
<div class="loader" id="AjaxLoader" style="display:none;">  
       <div class="strip-holder">  
           <div class="strip-1"></div>  
           <div class="strip-2"></div>  
           <div class="strip-3"></div>  
       </div>  
   </div>  
Loader Script  
<script>  
    $(document)  
        .ajaxStart(function () {  
            $('#AjaxLoader').show();  
        })  
        .ajaxStop(function () {  
            $('#AjaxLoader').hide();  
        });  
</script>  
The above script will call on every AJAX call, so we don't need to call loader function for each AJAX call. 

Step 5

Now, we are going to create an AJAX function and sleep system for a few seconds so we can see the loader.

On Home Controller, create a new Action (put the below code).

 
public JsonResult CallingAjaxFunction()  
       {  
           System.Threading.Thread.Sleep(7000);  
           return Json(true,JsonRequestBehavior.AllowGet);  
       }  
On Index page, we are going to call this method.
 
Index.cshtml  
@{  
    ViewBag.Title = "Home Page";  
}  
  
<div class="jumbotron">  
    <h1>ASP.NET</h1>  
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>  
    <p><a class="btn btn-primary btn-lg" id="ajaxCall" onclick="CallMe()">Call Me »</a></p>  
</div>  
  
<div class="row">  
    <div class="col-md-4">  
        <h2>Getting started</h2>  
        <p>  
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that  
            enables a clean separation of concerns and gives you full control over markup  
            for enjoyable, agile development.  
        </p>  
        <p><a href="https://asp.net" class="btn btn-default">Learn more »</a></p>  
    </div>  
    <div class="col-md-4">  
        <h2>Get more libraries</h2>  
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>  
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more »</a></p>  
    </div>  
    <div class="col-md-4">  
        <h2>Web Hosting</h2>  
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>  
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn more »</a></p>  
    </div>  
</div>  
<script>  
    function CallMe() {  
        $.ajax({  
            type: "GET",  
            url: '@Url.Action("CallingAjaxFunction", "Home")',  
            contentType: "application/json; charset=utf-8",  
            dataType: "json",  
            success: function (recData) { alert('Success'); },  
            error: function () { alert('A error'); }  
        });  
    }  
</script>  
HomeController.cs  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
  
namespace AjaxDemo.Controllers  
{  
    public class HomeController : Controller  
    {  
        public ActionResult Index()  
        {  
            return View();  
        }  
  
        public ActionResult About()  
        {  
            ViewBag.Message = "Your application description page.";  
  
            return View();  
        }  
  
        public ActionResult Contact()  
        {  
            ViewBag.Message = "Your contact page.";  
  
            return View();  
        }  
  
        public JsonResult CallingAjaxFunction()  
        {  
            System.Threading.Thread.Sleep(7000);  
            return Json(true,JsonRequestBehavior.AllowGet);  
        }  
  
    }  
}  
And that's all. Now, whenever you call any AJAX function from any page, the loader will show while loading/executing your content and hide when it's done/complete.
 
Output 
 
