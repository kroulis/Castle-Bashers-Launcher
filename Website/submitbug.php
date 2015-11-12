<?php
	//Get the information from the client.
	$userid=$_REQUEST["Playerid"];
	$errorid=$_REQUEST["ErrorID"];
	$text=$_REQUEST["Describe"];
	
	if($userid==null)
		die('Failed. No Player ID.');
	if($errorid==null)
		die('Failed. No Error ID');
	if($text==null)
		die('Failed. No Describe');
	
	//Get the time for the Mysql.	
	$time=date('Y-m-d H:i:s');
	//Connect to the Mysql
	$host="127.0.0.1";
	$manager="castlebashers";
	$password="";
	$mysql=mysql_connect($host,$manager,$password);
	mysql_query("set names 'utf8'");
	mysql_select_db("castlebashers");
	//Ready to write
	$sql = "insert into bugreport (Player_ID,Error_ID,Describe_Text,Submit_Time,Fixed)  values('$userid','$errorid','$text','$time','0')";
	$result=mysql_query($sql,$mysql);
	if (!$result)
	{
		die('Failed. ' . mysql_error());
	}
	echo 'Submit Success.';
?>