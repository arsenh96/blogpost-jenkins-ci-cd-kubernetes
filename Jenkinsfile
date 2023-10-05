pipeline {
    agent any 
    environment {
        DOCKER_USERNAME = 'arsenharutjunjan'
        DOCKER_PASSWORD = 'Password123!'
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Test') {
            steps {
                dir('HelloWorldWebApp.Tests') { // Navigeer naar de submap
                    bat 'dotnet test' // Voer de tests uit
                }
            }
        }
        stage('Docker Build and Push') {
            steps {
 		sh 'pwd'  // Toont de huidige werkdirectory
        	sh 'ls -al'  // Toont alle bestanden in de huidige directory
                sh '''
                    echo "$DOCKER_PASSWORD" | docker login -u $DOCKER_USERNAME --password-stdin
                    docker build -t $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes -f HelloWorldWebApp/Dockerfile .
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
