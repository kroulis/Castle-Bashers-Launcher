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
    $callback=$_GET['callback'];  
	if($userName=="")
		die('No Player Name');
	if($mysql==true)
	{
		 mysql_select_db("castlebashers");
		 $sql = "insert into playerid (ip,name,regtime)  values('$getip','$userName','$time')";
		 $result=mysql_query($sql,$mysql);
		 if (!$result)
		 {
		   		$arr = array ('pid'=>"FAILED",'status'=>"106",'Message'=>mysql_error());
		 		$json=json_encode($arr); 
				echo $callback."($json)";  
		 }
		 else
		 {
		 	$pid='OP'.str_pad(mysql_insert_id(),5,"0",STR_PAD_LEFT);
		 	$arr = array ('pid'=>$pid,'status'=>"101",'Message'=>"Register Success.",'insert_id'=>(string)mysql_insert_id());
		 	$json=json_encode($arr); 
			echo $callback."($json)";
		 }
		 
	}
	else
	{
		$arr = array ('pid'=>"FAILED",'status'=>"105",'Message'=>"Mysql Connect failed.");
		$json=json_encode($arr); 
		echo $callback."($json)"; 
	}
?>