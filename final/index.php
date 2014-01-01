﻿<HTML>
  <HEAD>
    <TITLE>MechZoneModPack</TITLE>
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8" />
    <STYLE TYPE="text/css">
<!--
BODY{margin-top:20px; margin-left:20px; margin-right:20px; color:#000000; font-family:Tahoma; background-color:white}
A:link {font-weight:normal; color:#000066; text-decoration:none}
A:visited {font-weight:normal; color:#000066; text-decoration:none}
A:active {font-weight:normal; text-decoration:none}
A:hover {font-weight:normal; color:#FF6600; text-decoration:none}
P {margin-top:0px; margin-bottom:12px; color:#000000; font-family:Tahoma}
PRE {border-right:#f0f0e0 1px solid; padding-right:5px; border-top:#f0f0e0 1px solid; margin-top:-5px; padding-left:5px; font-size:x-small; padding-bottom:5px; border-left:#f0f0e0 1px solid; padding-top:5px; border-bottom:#f0f0e0 1px solid; font-family:Courier New; background-color:#e5e5cc}
TD {font-size:12px; color:#000000; font-family:Tahoma}
H2 {border-top: #003366 1px solid; margin-top:25px; font-weight:bold; font-size:1.5em; margin-bottom:10px; margin-left:-15px; color:#003366}
H3 {margin-top:10px; font-size: 1.1em; margin-bottom: 10px; margin-left: -15px; color: #000000}
UL {margin-top:10px; margin-left:20px}
OL {margin-top:10px; margin-left:20px}
LI {margin-top:10px; color: #000000}
FONT.value {font-weight:bold; color:darkblue}
FONT.key {font-weight: bold; color: darkgreen}
.divTag {border:1px; border-style:solid; background-color:#FFFFFF; text-decoration:none; height:auto; width:auto; background-color:#cecece}
.BannerColumn {background-color:#000000}
.Banner {border:0; padding:0; height:8px; margin-top:0px; color:#ffffff; filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#1c5280',EndColorStr='#FFFFFF');}
.BannerTextCompany {font:bold; font-size:18pt; color:#cecece; font-family:Tahoma; height:0px; margin-top:0; margin-left:8px; margin-bottom:0; padding:0px; white-space:nowrap; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}
.BannerTextApplication {font:bold; font-size:18pt; font-family:Tahoma; height:0px; margin-top:0; margin-left:8px; margin-bottom:0; padding:0px; white-space:nowrap; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}
.BannerText {font:bold; font-size:18pt; font-family:Tahoma; height:0px; margin-top:0; margin-left:8px; margin-bottom:0; padding:0px; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}
.BannerSubhead {border:0; padding:0; height:16px; margin-top:0px; margin-left:10px; color:#ffffff; filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#4B3E1A',EndColorStr='#FFFFFF');}
.BannerSubheadText {font:bold; height:11px; font-size:11px; font-family:Tahoma; margin-top:1; margin-left:10; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}
.FooterRule {border:0; padding:0; height:1px; margin:0px; color:#ffffff; filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#4B3E1A',EndColorStr='#FFFFFF');}
.FooterText {font-size:11px; font-weight:normal; text-decoration:none; font-family:Tahoma; margin-top:10; margin-left:0px; margin-bottom:2; padding:0px; color:#999999; white-space:nowrap}
.FooterText A:link {font-weight:normal; color:#999999; text-decoration:underline}
.FooterText A:visited {font-weight:normal; color:#999999; text-decoration:underline}
.FooterText A:active {font-weight:normal; color:#999999; text-decoration:underline}
.FooterText A:hover {font-weight:normal; color:#FF6600; text-decoration:underline}
.ClickOnceInfoText {font-size:11px; font-weight:normal; text-decoration:none; font-family:Tahoma; margin-top:0; margin-right:2px; margin-bottom:0; padding:0px; color:#000000}
.InstallTextStyle {font:bold; font-size:14pt; font-family:Tahoma; a:#FF0000; text-decoration:None}
.DetailsStyle {margin-left:30px}
.ItemStyle {margin-left:-15px; font-weight:bold}
.StartColorStr {background-color:#4B3E1A}
.JustThisApp A:link {font-weight:normal; color:#000066; text-decoration:underline}
.JustThisApp A:visited {font-weight:normal; color:#000066; text-decoration:underline}
.JustThisApp A:active {font-weight:normal; text-decoration:underline}
.JustThisApp A:hover {font-weight:normal; color:#FF6600; text-decoration:underline}
-->

</STYLE>

<SCRIPT LANGUAGE="JavaScript">
<!--
runtimeVersion = "4.5.0";
checkClient = false;
directLink = "MechZoneModPack.application";


function Initialize()
{
  if (HasRuntimeVersion(runtimeVersion, false) || (checkClient && HasRuntimeVersion(runtimeVersion, checkClient)))
  {
    InstallButton.href = directLink;
    BootstrapperSection.style.display = "none";
  }
}
function HasRuntimeVersion(v, c)
{
  var va = GetVersion(v);
  var i;
  var a = navigator.userAgent.match(/\.NET CLR [0-9.]+/g);
  if(va[0]==4)
    a = navigator.userAgent.match(/\.NET[0-9.]+E/g);
  if (c)
  {
    a = navigator.userAgent.match(/\.NET Client [0-9.]+/g);
    if (va[0]==4)
       a = navigator.userAgent.match(/\.NET[0-9.]+C/g);
  }
  if (a != null)
    for (i = 0; i < a.length; ++i)
      if (CompareVersions(va, GetVersion(a[i])) <= 0)
                                return true;
  return false;
}
function GetVersion(v)
{
  var a = v.match(/([0-9]+)\.([0-9]+)\.([0-9]+)/i);
  if(a==null)
     a = v.match(/([0-9]+)\.([0-9]+)/i);
  return a.slice(1);
}
function CompareVersions(v1, v2)
{
   if(v1.length>v2.length)
   {
      v2[v2.length]=0;
   }  
   else if(v1.length<v2.length)
   {
      v1[v1.length]=0;
   }

  for (i = 0; i < v1.length; ++i)
  {
    var n1 = new Number(v1[i]);
    var n2 = new Number(v2[i]);
    if (n1 < n2)
      return -1;
    if (n1 > n2)
      return 1;
  }
  return 0;
}

-->
</SCRIPT>

</HEAD>
  <BODY ONLOAD="Initialize()">
    <TABLE WIDTH="100%" CELLPADDING="0" CELLSPACING="2" BORDER="0">

<!-- Begin Banner -->
<TR><TD><TABLE CELLPADDING="2" CELLSPACING="0" BORDER="0" BGCOLOR="#cecece" WIDTH="100%"><TR><TD><TABLE BGCOLOR="#1c5280" WIDTH="100%" CELLPADDING="0" CELLSPACING="0" BORDER="0"><TR><TD CLASS="Banner" /></TR><TR><TD CLASS="Banner"><SPAN CLASS="BannerTextCompany">MechZone</SPAN></TD></TR><TR><TD CLASS="Banner"><SPAN CLASS="BannerTextApplication">MechZoneModPack</SPAN></TD></TR><TR><TD CLASS="Banner" ALIGN="RIGHT" /></TR></TABLE></TD></TR></TABLE></TD></TR>
<!-- End Banner -->


<!-- Begin Dialog -->
<TR><TD ALIGN="LEFT"><TABLE CELLPADDING="2" CELLSPACING="0" BORDER="0" WIDTH="540"><TR><TD WIDTH="496">

<!-- Begin AppInfo -->
<TABLE><TR><TD COLSPAN="3">&nbsp;</TD></TR><TR><TD><B>Name:</B></TD><TD WIDTH="5"><SPACER TYPE="block" WIDTH="10" /></TD><TD>MechZoneModPack</TD></TR><TR><TD COLSPAN="3">&nbsp;</TD></TR><TR><TD><B>Version:</B></TD><TD WIDTH="5"><SPACER TYPE="block" WIDTH="10" /></TD><TD>1.0.0.49</TD></TR><TR><TD COLSPAN="3">&nbsp;</TD></TR><TR><TD><B>Herausgeber:</B></TD><TD WIDTH="5"><SPACER TYPE="block" WIDTH="10" /></TD><TD>MechZone</TD></TR><tr><td colspan="3">&nbsp;</td></tr></TABLE>
<!-- End AppInfo -->


<!-- Begin Prerequisites -->
<TABLE ID="BootstrapperSection" BORDER="0"><TR><TD COLSPAN="2">Die folgenden Komponenten sind erforderlich:</TD></TR><TR><TD WIDTH="10">&nbsp;</TD><TD><UL>
<LI>Microsoft .NET Framework 4.5 (x86 and x64)</LI>
</UL></TD></TR><TR><TD COLSPAN="2">
Falls diese Komponenten bereits installiert wurden, können Sie die Anwendung jetzt <SPAN CLASS="JustThisApp"><A HREF="MechZoneModPack.application">starten</A></SPAN>. Klicken Sie andernfalls auf die Schaltfläche unten, um die erforderlichen Komponenten zu installieren und die Anwendung auszuführen.
</TD></TR><TR><TD COLSPAN="2">&nbsp;</TD></TR></TABLE>
<!-- End Prerequisites -->


</TD></TR></TABLE>
<!-- Begin Buttons -->
<TR><TD ALIGN="LEFT"><TABLE CELLPADDING="2" CELLSPACING="0" BORDER="0" WIDTH="540" STYLE="cursor:hand" ONCLICK="window.navigate(InstallButton.href)"><TR><TD ALIGN="LEFT"><TABLE CELLPADDING="1" BGCOLOR="#333333" CELLSPACING="0" BORDER="0"><TR><TD><TABLE CELLPADDING="1" BGCOLOR="#cecece" CELLSPACING="0" BORDER="0"><TR><TD><TABLE CELLPADDING="1" BGCOLOR="#efefef" CELLSPACING="0" BORDER="0"><TR><TD WIDTH="20"><SPACER TYPE="block" WIDTH="20" HEIGHT="1" /></TD><TD><A ID="InstallButton" HREF="setup.exe">Installieren</A></TD><TD width="20"><SPACER TYPE="block" WIDTH="20" HEIGHT="1" /></TD></TR></TABLE></TD></TR></TABLE></TD></TR></TABLE></TD><TD WIDTH="15%" ALIGN="right" /></TR></TABLE></TD></TR>
<!-- End Buttons -->
</TD></TR>
<!-- End Dialog -->



<!-- Spacer Row -->
<TR><TD>&nbsp;</TD></TR>

<TR><TD>
<!-- Begin Footer -->
<TABLE WIDTH="100%" CELLPADDING="0" CELLSPACING="0" BORDER="0" BGCOLOR="#ffffff"><TR><TD HEIGHT="5"><SPACER TYPE="block" HEIGHT="5" /></TD></TR><TR><TD CLASS="FooterText" ALIGN="center">
<A HREF="http://mechzone.net">MechZone-Kundensupport</A>
&nbsp;&nbsp;&nbsp;::&nbsp;&nbsp;&nbsp;
<A HREF="http://go.microsoft.com/fwlink/?LinkId=154571">ClickOnce- und .NET Framework-Ressourcen</A>
</TD></TR><TR><TD HEIGHT="5"><SPACER TYPE="block" HEIGHT="5" /></TD></TR><TR><TD HEIGHT="1" bgcolor="#cecece"><SPACER TYPE="block" HEIGHT="1" /></TD></TR></TABLE>
<!-- End Footer -->
</TD></TR>

</TABLE>
  </BODY>
</HTML>