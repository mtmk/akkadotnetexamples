# Akka.Net .Net Core Docker Cluster Example

    sh build_all.sh 
    docker-compose run

## Sample output (edited for clarity)

    node1_1  | [akka://acme/user/start]] Tick..
    node3_1  | [akka://acme/user/task3]] [TASK3] Got work to do 1 - Work-20:19:42.8507806
    node2_1  | [akka://acme/user/task2]] [TASK2] Got work to do 1 - Work-20:19:42.8441049
    node1_1  | [akka://acme/user/start]] Tick..
    node3_1  | [akka://acme/user/task3]] [TASK3] Got work to do 2 - Work-20:19:45.8528589
    node2_1  | [akka://acme/user/task2]] [TASK2] Got work to do 2 - Work-20:19:45.8527551
    node1_1  | [akka://acme/user/start]] Tick..
    node2_1  | [akka://acme/user/task2]] [TASK2] Got work to do 3 - Work-20:19:48.8633539
    node3_1  | [akka://acme/user/task3]] [TASK3] Got work to do 3 - Work-20:19:48.8635029
    node1_1  | [akka://acme/user/start]] Tick..
    node2_1  | [akka://acme/user/task2]] [TASK2] Got work to do 4 - Work-20:19:51.8722198
    node3_1  | [akka://acme/user/task3]] [TASK3] Got work to do 4 - Work-20:19:51.8723006

## Run individual services locally

    cd seed1
    dotnet run seed1.conf --local
