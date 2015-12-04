<?php
	header('Content-type: text/json'); 
	$host="127.0.0.1";
	$manager="castlebashers";
	$password="";
	$mysql=mysql_connect($host,$manager,$password);
	mysql_query("set names 'utf8'");
	if($mysql==true)
	{
		 mysql_select_db("castlebashers");
		 $sql = "select * from playerid";
		 $result=mysql_query($sql,$mysql);
		 if (!$result)
		 {
		   die();
		 }
		 $num=mysql_num_rows($result);
		 $arr = array ('player_num'=>(string)$num);
		 $json=json_encode($arr); 
		 $callback=$_GET['callback'];  
		 echo $callback."($json)";  
	}
	else
	{
		die();
	}
?>