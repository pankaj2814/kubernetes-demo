| Repo | URL |
| ------ | ------ |
| Git | https://github.com/pankaj2814/kubernetes-demo |
| Docker | https://hub.docker.com/r/pankaj2814/employee-api-pankaj |


# Setps to Run:-
### 1) Create password secret using followind command 

```
kubectl create secret generic mssql-config --from-literal=password='password'
```
> Note: change highlighted text in above to your desired password.
...from-literal=password=' `password`' 

### 2) Setup Kubernetes using following commands
```
kubectl apply -f .\kube\config-map.yaml
```
```
kubectl apply -f .\kube\mysql-pv.yaml
```
```
kubectl apply -f .\kube\mysql.yaml
```
```
kubectl apply -f .\kube\api.yaml
```

### 3) View API
Open ` http://localhost:30123/Employees` in browser.
> Swagger is also availabe @ ` http://localhost:30123/swagger/index.html ` 

### build docker image
```
docker build -t pankaj2814/employee-api-pankaj:latest . 
```