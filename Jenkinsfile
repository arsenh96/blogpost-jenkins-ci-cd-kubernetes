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
                sh './run-tests.sh'
            }
        }

        stage('Docker Build and Push') {
            steps {
                sh '''
                    docker build -t myapp .
                    docker push myapp:latest
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
    }
}
