UNITY_VERSION=2018.4.0f1
docker run -it --rm \
-e "UNITY_USERNAME=gclenden@calpoly.edu" \
-e "UNITY_PASSWORD=Vigeant11*" \
-e "TEST_PLATFORM=linux" \
-e "WORKDIR=/root/project" \
-v "$(pwd):/root/project" \
gableroux/unity3d:$UNITY_VERSION \
bash

