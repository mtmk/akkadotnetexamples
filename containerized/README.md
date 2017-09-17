# Akka.Net .Net Core Docker Cluster Example

    $ sh build_all.sh 
    $ docker-compose run
    (Ctrl-C to stop)
    
## Sample output (edited for clarity)

    node1_1  | [akka://acme/user/start] Tick..
    node3_1  | [akka://acme/user/task3] [TASK3] Got work to do 1 - Work-20:19:42.8507806
    node2_1  | [akka://acme/user/task2] [TASK2] Got work to do 1 - Work-20:19:42.8441049

## Scaling

Start the cluster

    $ docker-compose up -d

Scale up node2 and 3

    $ docker-compose scale node2=3 node3=3

Sample output: (notice node2 and 3 are reporting more)

    $ docker-compose logs
    node1_1  | [akka://acme/user/start] Tick..
    node2_1  | [akka://acme/user/task2] [TASK2] Got work to do 30 - Work-23:00:13.9481288
    node2_3  | [akka://acme/user/task2] [TASK2] Got work to do 30 - Work-23:00:13.9481288
    node3_3  | [akka://acme/user/task3] [TASK3] Got work to do 30 - Work-23:00:13.9481954
    node3_1  | [akka://acme/user/task3] [TASK3] Got work to do 30 - Work-23:00:13.9481954
    node3_2  | [akka://acme/user/task3] [TASK3] Got work to do 30 - Work-23:00:13.9481954
    node2_2  | [akka://acme/user/task2] [TASK2] Got work to do 30 - Work-23:00:13.9481288

## Run individual services locally

    cd seed1
    dotnet run seed1.conf --local
