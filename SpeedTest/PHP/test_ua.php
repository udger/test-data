<?php
/**
 * UdgerParser - test speed UA
 * 
 * @author     The Udger.com Team (info@udger.com)
 * @license    http://www.gnu.org/licenses/lgpl.html GNU Lesser General Public License
 * @link       http://udger.com/products/local_parser
 */

echo "start\n";

require_once '/vendor/autoload.php';

$factory = new Udger\ParserFactory("udgerdb_v3.dat");
//$factory = new Udger\ParserFactory("udgerdb_v3-noip.dat"); // no ip information DB

$parser = $factory->getParser();
//$parser->setCacheEnable(false);
//$parser->setCacheSize(4000);

echo "download test UA file start\n";
$fh = fopen('https://raw.githubusercontent.com/udger/test-data/master/test_ua-ip/ua_1000.txt','r');

echo "download test UA file end\n";

echo "parse UA start\n";
$start = microtime(true);
while ($line = fgets($fh)) {
      $line = trim($line);
      $i++;
      //echo $i."\n";
      $parser->setUA($line);
      $ret = $parser->parse();
      //var_dump($ret);
      //$parser->clearCache();
}
fclose($fh);

$time_elapsed_secs = microtime(true) - $start;
echo "parse UA end, time: ". $time_elapsed_secs;

echo "\nend\n";

?>