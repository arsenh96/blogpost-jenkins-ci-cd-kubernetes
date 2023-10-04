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
        stage('Docker Build and Push') {
            steps {
                dir('C:/src/minor_devops/blogpost-jenkins-ci-cd-kubernetes/HelloWorldWebApp') {
                    sh '''
                        docker build -t arsenharutjunjan/blogpost-jenkins-ci-cd-kubernetes -f Dockerfile .
                        docker push arsenharutjunjan/blogpost-jenkins-ci-cd-kubernetes:latest
                    '''
                }
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
