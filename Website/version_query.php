<?php
/*
	Castle Bashers --Version Query
	For:1.MainVersion		
*/
	session_start();
	$qid=$_REQUEST['qid'];
	//echo $qid;
	if($qid == "")  die("QUERY ERROR: UNKNOWN ACTION");
	$xml = new DOMDocument(); 
	
	if($qid=="mv") //query for main version
	{
		$xml->load('mainversion.xml');
		//echo $type_s;
		$software = $xml->getElementsByTagName("alpha")->item(0);
		$version = $software->getElementsByTagName("version")->item(0);
		echo $version->nodeValue;
		exit();
	}
	
	if($qid=="um") //query for updata mainprogram files address
	{
		$xml->load('mainversion.xml');
		$software = $xml->getElementsByTagName("alpha")->item(0);
		$vnode = $software->getElementsByTagName("vnode")->item(0);
		$preaddress=$software->getElementsByTagName("fileaddress")->item(0);
		$version=$_REQUEST['version'];
		if($version=="")
		{
			die("QUERY ERROR: UNKNOWN VERSION");
		}
		else
		{
			$va=$vnode->getElementsByTagName("$version")->item(0);
			if($va==null)
				die("QUERY ERROR: ERROR VERSION");
			while($va->nodeValue!="-1")
			{
				$address= $preaddress->getElementsByTagName("$va->nodeValue")->item(0);
				echo $address->nodeValue . "#";
				$va=$vnode->getElementsByTagName("$va->nodeValue")->item(0);
			}
			echo "-1";
		}
		exit();
	}
	
	die("QUERY ERROR: UNKNOWN ACTION");

?>