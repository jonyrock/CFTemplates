work_port="$(cat .sessionCfg)"
wget "127.0.0.1:$work_port" -q -b
rm wget-log*
rm index*