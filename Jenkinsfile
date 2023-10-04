pipeline {
    agent any 
    environment {
        DOCKER_HUB_TOKEN = 'dckr_pat_YwY2kqTtSEAxG2Eo6McVYL03VnM'
        DOCKER_USERNAME = 'arsenharutjunjan'
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Test') {
            steps {
                sh 'wsl nohup ./run-tests.sh &'
            }
        }
        stage('Docker Build and Push') {
            steps {
                sh '''
                    docker login -u $DOCKER_USERNAME -p $DOCKER_HUB_TOKEN
                    docker build -t $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes .
                    docker push $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes:latest
                '''
            }
        }
        /*
        stage('Kubernetes Deployment') {
            steps {
                sh 'kubectl create -f myapp-deployment.yaml'
            }
        }
        stage('Verify Deployment') {
            steps {
                sh 'kubectl get deployments'
            }
        }
        */
    }
}
