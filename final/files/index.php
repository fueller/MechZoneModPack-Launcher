<!DOCTYPE html>
<html>
  <head>
    <title>Mod Tabelle</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Bootstrap -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="bootstrap/assets/js/html5shiv.js"></script>
      <script src="bootstrap/assets/js/respond.min.js"></script>
    <![endif]-->
	</script>
  </head>
  <body>
	<table class="table table-bordered table-hover table-condensed">
	<?php
	$myFile = "mods.json";
	$fh = fopen($myFile, 'r');
	$theData = fread($fh, filesize($myFile));
	fclose($fh);
	//var_dump(json_decode($theData));
	$data = json_decode($theData, true);

	$count = count($data["files"]);
	?>
	<button type="button" class="btn btn-default" onclick="location.href='index2.php'">Files</button>
	<button type="button" class="btn btn-default" onclick="location.href='index3.php'">Configs</button>
	<?php
	echo "<tr>";
	echo "<th>Nr</th><th>Name</th><th>Version</th><th>Link</th><th>Download</th><th>Pfad</th>";
	echo "</tr>";
	for ($i = 1; $i < $count; $i++) {
		echo "<tr>";
		echo "<th> " . $i . "</th>";
		echo "<th> " . $data["files"][$i]["name"] . " </th>";
		echo "<th> " . $data["files"][$i]["version"] . " </th>";
		echo "<th> <a href=\"" . $data["files"][$i]["forumLink"] . "\">" . $data["files"][$i]["forumLink"] . "</a></th>";
		echo "<th> <a href=\"" . $data["files"][$i]["url"] . "\">" . $data["files"][$i]["url"] . "</a></th>";
		echo "<th> " . $data["files"][$i]["path"] . " </th>";
		echo "</tr>";
	}
	?>
	</table>
    
    <script src="//code.jquery.com/jquery.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
  </body>
</html>



