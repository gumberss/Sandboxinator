# 1 - Criar politicas de segurança
# 2 - Criar role de segurança na AWS

aws iam create-role 
  --role-name lambda-example 
  --assume-role-policy-document file://politics.json 
  | tee logs/role.log

# 3 - Criar arquivo com conteúdo e zipa-lo
powershell Compress-Archive index.js function.zip

# 4 - Enviar handler para a AWS

aws lambda create-function
  --function-name hello-cli
  --zip-file fileb://function.zip
  --handler index.handler
  --runtime nodejs12.x
  --role arn:aws:iam::844041051627:role/lambda-exemple
  | tee logs/lambda-create.log

# 5 - Executar lambda

aws lambda invoke
  --function-name hello-cli
  --log-type Tail
  logs/lambda-exec.log

# 6 - Update handler

aws lambda update-function-code
  --function-name hello-cli
  --zip-file fileb://function.zip
  --publish
  | tee logs/update-lambda.log

# 7 - Remover function
aws lambda delete-function
  --function-name hello-cli

# 8 - Remover role
aws iam delete-role
  --role-name lambda-example
