<?php
	$host="127.0.0.1";
	$manager="castlebashers";
	$password="";
	$mysql=mysql_connect($host,$manager,$password);
	mysql_query("set names 'utf8'");
	function get_real_ip(){
		$ip=false;
		if(!empty($_SERVER["HTTP_CLIENT_IP"]))
		{
			$ip = $_SERVER["HTTP_CLIENT_IP"];
		}
		if (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) 
		{
			$ips = explode (", ", $_SERVER['HTTP_X_FORWARDED_FOR']);
			if ($ip) 
			{
				 array_unshift($ips, $ip); 
				 $ip = FALSE; 
			}
			for ($i = 0; $i < count($ips); $i++) 
			{
				if (!eregi ("^(10|172\.16|192\.168)\.", $ips[$i])) 
				{
					$ip = $ips[$i];
					break;
				}
			}
		}
		return ($ip ? $ip : $_SERVER['REMOTE_ADDR']);
	}
	$getip=mysql_escape_string(get_real_ip());
	$userName=$_REQUEST["playername"];
	$time=date('Y-m-d H:i:s');
	if($userName=="")
		die('No Player Name');
	if($mysql==true)
	{
		 mysql_select_db("castlebashers");
		 $sql = "insert into playerid (ip,name,regtime)  values('$getip','$userName','$time')";
		 $result=mysql_query($sql,$mysql);
		 if (!$result)
		 {
		   die('Error: ' . mysql_error());
		 }
		 $pid='OP'.str_pad(mysql_insert_id(),5,"0",STR_PAD_LEFT);
		 echo $pid;
	}
	else
	{
		die("Mysql Connect failed.");
	}
?>