DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
work_port="$(cat $DIR/.sessionCfg)"
wget "127.0.0.1:$work_port" -q -b & rm wget-log* & rm index.html*

