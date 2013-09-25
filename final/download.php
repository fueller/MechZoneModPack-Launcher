<?php
$downloadfile = "vBoxingModPack.application";
$filename = "vBoxingModPack.application";
$filesize = filesize($downloadfile);

header("Content-Type: image/jpeg"); 
header("Content-Disposition: attachment; filename='$filename'"); 
header("Content-Length: $filesize");

readfile($downloadfile);
exit;
?>