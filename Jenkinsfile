pipeline {
    agent any 

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }
        
        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }
        
        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }

        stage('Deploy') {
            steps {
                bat '.\\deploy.ps1' // Aanpassen aan jouw scriptnaam en locatie
            }
        }
    }
}
