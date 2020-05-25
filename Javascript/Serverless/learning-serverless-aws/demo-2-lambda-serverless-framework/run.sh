# Install serverless framework
npm install -g serverless

# Start project
sls
 
# deploy 
sls deploy

# invoke AWS
sls invoke -f hello

# invoke local
sls invoke local -f hello -l # -l == log

# Configure dashboard
sls

# deploy again
sls deploy

# logs 
sls logs -f hello --tail

#remove everthing
sls remove
