pipeline {
    agent any 
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
        // Commentaar voor nu om te focussen op het testen
        /*
        stage('Docker Build and Push') {
            steps {
                sh '''
                    docker build -t arsenharutjunjan/blogpost-jenkins-ci-cd-kubernetes .
                    docker push arsenharutjunjan/blogpost-jenkins-ci-cd-kubernetes:latest
                '''
            }
        }
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
