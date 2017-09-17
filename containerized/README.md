# Akka.Net .Net Core Docker Cluster Example

    sh build_all.sh 
    docker-compose run

Sample output

    seed1_1  | [INFO][09/17/2017 20:19:40][Thread 0003][[akka://acme/system/cluster/core/daemon#2061387151]] Node [akka.tcp://acme@020673c14842:38609] is JOINING, roles [role1]
    seed1_1  | [INFO][09/17/2017 20:19:40][Thread 0003][[akka://acme/system/cluster/core/daemon#2061387151]] Node [akka.tcp://acme@a89dd27aa6a5:45373] is JOINING, roles [role3]
    seed1_1  | [INFO][09/17/2017 20:19:40][Thread 0003][[akka://acme/system/cluster/core/daemon#2061387151]] Node [akka.tcp://acme@26f8bb511e9d:34201] is JOINING, roles [role2]
    node1_1  | [INFO][09/17/2017 20:19:40][Thread 0003][[akka://acme/system/cluster/core/daemon#25496921]] Welcome from [akka.tcp://acme@seed1:8080]
    node2_1  | [INFO][09/17/2017 20:19:40][Thread 0004][[akka://acme/system/cluster/core/daemon#60031649]] Welcome from [akka.tcp://acme@seed1:8080]
    node3_1  | [INFO][09/17/2017 20:19:40][Thread 0005][[akka://acme/system/cluster/core/daemon#242824311]] Welcome from [akka.tcp://acme@seed1:8080]
    seed1_1  | [INFO][09/17/2017 20:19:41][Thread 0018][[akka://acme/system/cluster/core/daemon#2061387151]] Leader is moving node [akka.tcp://acme@020673c14842:38609] to [Up]
    seed1_1  | [INFO][09/17/2017 20:19:41][Thread 0018][[akka://acme/system/cluster/core/daemon#2061387151]] Leader is moving node [akka.tcp://acme@26f8bb511e9d:34201] to [Up]
    seed1_1  | [INFO][09/17/2017 20:19:41][Thread 0018][[akka://acme/system/cluster/core/daemon#2061387151]] Leader is moving node [akka.tcp://acme@a89dd27aa6a5:45373] to [Up]
    node1_1  | [INFO][09/17/2017 20:19:42][Thread 0004][[akka://acme/user/startup#1606400642]] Tick..
    node3_1  | [INFO][09/17/2017 20:19:42][Thread 0006][[akka://acme/user/task3#1452974708]] [TASK3]Got work to do 1 - Work-20:19:42.8507806
    node2_1  | [INFO][09/17/2017 20:19:42][Thread 0003][[akka://acme/user/task2#1141702245]] [TASK2] Got work to do 1 - Work-20:19:42.8441049
    node1_1  | [INFO][09/17/2017 20:19:45][Thread 0018][[akka://acme/user/startup#1606400642]] Tick..
    node3_1  | [INFO][09/17/2017 20:19:45][Thread 0005][[akka://acme/user/task3#1452974708]] [TASK3]Got work to do 2 - Work-20:19:45.8528589
    node2_1  | [INFO][09/17/2017 20:19:45][Thread 0005][[akka://acme/user/task2#1141702245]] [TASK2] Got work to do 2 - Work-20:19:45.8527551
    node1_1  | [INFO][09/17/2017 20:19:48][Thread 0004][[akka://acme/user/startup#1606400642]] Tick..
    node2_1  | [INFO][09/17/2017 20:19:48][Thread 0003][[akka://acme/user/task2#1141702245]] [TASK2] Got work to do 3 - Work-20:19:48.8633539
    node3_1  | [INFO][09/17/2017 20:19:48][Thread 0003][[akka://acme/user/task3#1452974708]] [TASK3]Got work to do 3 - Work-20:19:48.8635029
    node1_1  | [INFO][09/17/2017 20:19:51][Thread 0003][[akka://acme/user/startup#1606400642]] Tick..
    node2_1  | [INFO][09/17/2017 20:19:51][Thread 0021][[akka://acme/user/task2#1141702245]] [TASK2] Got work to do 4 - Work-20:19:51.8722198
    node3_1  | [INFO][09/17/2017 20:19:51][Thread 0004][[akka://acme/user/task3#1452974708]] [TASK3]Got work to do 4 - Work-20:19:51.8723006

Run individual services locally

    cd seed1
    dotnet run seed1.conf --local
