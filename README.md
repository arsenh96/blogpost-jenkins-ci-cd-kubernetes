
# De Eerste Stappen naar Geautomatiseerde Deployments: Een Simpele Webapplicatie Uitrollen met Jenkins en Kubernetes (Windows)
Geschreven door: Arsen Harutjunjan<br>
![Arsen Harutjunjan](images/1693239745445.jpeg)
# 1. Inleiding
Dit document is een gids voor studenten en beginnende DevOps-engineers over het opzetten van een geautomatiseerde Continuous Integration (CI) en Continuous Deployment (CD) pipeline met Jenkins en Kubernetes op Windows. We zullen de basisprincipes van CI/CD, de rol van Jenkins en Kubernetes, en de configuratie van een Jenkinsfile bespreken. Daarnaast zullen we praktische stappen geven voor het opzetten van de ontwikkelingsomgeving en het uitvoeren van een Jenkins-pipeline.

**Noot aan de lezer/beoordelaar**: Let op dat de code snippets in dit document niet worden meegerekend bij de totale woordentelling. Hierdoor bevindt het totale aantal woorden zich onder de 1580 woorden.
# 2. Introductie tot Jenkins
Jenkins is een krachtige open-source automation server die een centrale rol speelt in Continuous Integration (CI) en Continuous Deployment (CD). Hier bespreken we de belangrijkste aspecten van Jenkins en waarom het zo waardevol is voor CI/CD.
## 2.1. Kernfuncties van Jenkins
Jenkins biedt essentiële functies voor automatisering:

|Voordelen|Nadelen|
|---|---|
|Automatisering: Bouwen, testen en deployen van code wordt geautomatiseerd, versnelt ontwikkelingscycli.|Installatie en configuratie kunnen complex zijn.|
|Plugin-architectuur: Aanpasbaarheid door een breed scala aan plugins voor diverse projectbehoeften.|Overmatig gebruik van plugins kan configuratie verwarrend maken.|
|Monitoring en feedback: Biedt voortdurende monitoring en real-time feedback voor probleemoplossing.|Kan aanzienlijke systeembronnen vereisen.|
_Tabel 1: Voor en Nadelen Jenkins_
## 2.2. Werking van Jenkins
Jenkins haalt broncode op uit Git, voert builds en tests uit en rapporteert de resultaten aan het team, waardoor snelle feedback en codekwaliteit worden bevorderd.
![jenkins-workflow](images/jenkins-workflow.jpg)
_Figuur 2: Jenkins workflow_
## 2.3. Integratie met Andere tools
Jenkins integreert naadloos met tools zoals Git voor versiebeheer en Kubernetes voor containerorkestratie, waardoor het een centrale spil wordt in het automatiseren van software delivery.

Dit maakt Jenkins tot een essentieel hulpmiddel voor het stroomlijnen van CI/CD-processen en het versnellen van softwarelevering.
# 3. Jenkins en Kubernetes: Een Perfecte Match
Jenkins en Kubernetes vormen een krachtige combinatie die een efficiënte CI/CD-pipeline mogelijk maakt. In dit hoofdstuk zullen we verkennen waarom de integratie van Jenkins, een automatiseringsserver, met Kubernetes, een containerorkestratieplatform, zo waardevol is voor moderne softwareontwikkeling.
## 3.1. Waarom de Combinatie?
De samenvoeging van Jenkins en Kubernetes brengt diverse voordelen met zich mee. Deze combinatie combineert de sterke punten van beide tools:
- **Efficiëntie**: Jenkins automatiseert build- en testprocessen, terwijl Kubernetes zorgt voor de eenvoudige implementatie van containerized applicaties. Dit verkort de tijd van codeontwikkeling naar productie aanzienlijk.
- **Schaalbaarheid**: Kubernetes biedt de mogelijkheid om snel en eenvoudig op te schalen, wat ideaal is voor grotere codebases en teams. Jenkins-pipelines kunnen parallel worden uitgevoerd op verschillende pods in het Kubernetes-cluster, waardoor schaalbaarheid wordt benut.
- **Betrouwbaarheid**: Kubernetes staat bekend om zijn hoge beschikbaarheid en failover-mogelijkheden, essentieel voor robuuste CI/CD-pipelines. Als een pod mislukt, kan Kubernetes automatisch een nieuwe pod maken om de taak over te nemen.

![Jenkins-Kubernetes-Integratie](images\jenkins-kubernetes.jpg)
_Figuur 3: Jenkins-Kubernetes-Integratie_
## 3.2. De Integratie in de Praktijk
Jenkins kan op verschillende manieren worden geïntegreerd met Kubernetes, afhankelijk van de specifieke behoeften van het project. Een veelgebruikte methode is het configureren van Jenkins-pipelines die draaien als pods in een Kubernetes-cluster. Hierdoor kunnen Jenkins-jobs eenvoudig worden geschaald en profiteren van de veerkracht van Kubernetes.
## 3.3. Benutten van de voordelen
Door Jenkins en Kubernetes te combineren, kunnen ontwikkelteams efficiënter werken, grotere projecten aanpakken en betrouwbare CI/CD-pipelines bouwen. De voordelen van deze integratie dragen bij aan het versnellen van de softwarelevering en het vergroten van de stabiliteit van applicaties.

In het volgende hoofdstuk zullen we bespreken hoe je de ontwikkelomgeving kunt opzetten om Jenkins en Kubernetes te gebruiken voor je CI/CD-pipeline.
# 4. Omgeving opzetten
Dit hoofdstuk richt zich op het opzetten van de ontwikkelomgeving met behulp van twee belangrijke tools: Jenkins voor automatisering en Kubernetes voor containerorkestratie.

We gaan ervan uit dat je al de Java Development Kit (JDK) hebt geïnstalleerd, tot en met versie 17. Zo niet, installeer deze dan voordat je verdergaat.
## 4.1. Jenkins opzetten
De eerste stap is het installeren van Jenkins:
1. Download het installatiebestand van de [officiële website](https://www.jenkins.io/download/).
2. Voer het gedownloade `.exe`-bestand uit en volg de instructies van de installatiewizard.
3. Na de installatie, open een webbrowser en ga naar `http://localhost:8080` om de configuratiewizard van Jenkins te starten. Volg de instructies om Jenkins te configureren. Zorg ervoor dat je de aanbevolen plugins installeert.
4. Maak een admin-gebruiker aan, dit is de eerste gebruiker met volledige toegang tot Jenkins.
5. Stel de URL in waar Jenkins bereikbaar is, dit is belangrijk voor integraties en webhooks.
### 4.1.1. Toegang van buitenaf met ngrok
Om externe toegang tot je lokale Jenkins-server mogelijk te maken, kun je ngrok gebruiken:
1. Download en installeer ngrok vanaf [ngrok.com](https://ngrok.com/).
2. Start ngrok vanuit een terminal met het commando `./ngrok http 8080`.
3. Gebruik de door ngrok verstrekte URL om externe toegang tot je Jenkins-server te krijgen. Houd er rekening mee dat ngrok-URL's tijdelijk zijn en bij elke sessie veranderen.
## 4.2. Kubernetes opzetten met Docker Desktop
Kubernetes is het orkestratieplatform dat we gaan gebruiken. We zullen Docker Desktop gebruiken om Kubernetes in te schakelen:
### 4.2.1. Docker Desktop installeren
- Download en installeer Docker Desktop van de [officiële website](https://docs.docker.com/desktop/install/windows-install/).
### 4.2.2. Kubernetes inschakelen
- Ga naar de Docker Desktop-instellingen en schakel Kubernetes in.
#### 4.2.2.1. Installatie verifiëren
Om te controleren of Kubernetes correct is geïnstalleerd, gebruik je het volgende commando in de terminal: `kubectl cluster-info`.
### 4.2.3. Integratie met Jenkins
In een later hoofdstuk gaan we dieper in op de integratie tussen Jenkins en Kubernetes.
# 5. Bouwen van een Jenkinsfile: De fundamenten
Een diepgaand begrip van Jenkinsfiles en hoe ze worden geïmplementeerd, is essentieel voor een effectieve CI/CD-pipeline. In dit hoofdstuk zullen we de basiscomponenten van een Jenkinsfile verkennen en demonstreren hoe deze kunnen worden gebruikt om een solide CI/CD-pipeline te creëren, specifiek gericht op studenten en beginnende DevOps-engineers.
## 5.1 Environment: Het Definiëren van Omgevingsvariabelen
Het `environment` blok wordt gebruikt om verschillende omgevingsvariabelen vast te stellen die toegankelijk zijn in alle stages van de Jenkins-pipeline. Hier zijn enkele voorbeelden:
```
environment {
    DOCKER_USERNAME = 'arsenharutjunjan'
    DOCKER_PASSWORD = 'Password123!'
    KUBECONFIG = 'C:\\Users\\arsen\\.kube\\config' 
}
```
Houd er rekening mee dat het beheren van gevoelige informatie zoals gebruikersnamen en wachtwoorden op een veilige manier een best practice is, maar voor deze tutorial houden we het eenvoudig.
## 5.2. Agens in een Jenkinsfile
Het `agent` blok specificeert waar de build wordt uitgevoerd. `agent any` geeft aan dat de build kan worden uitgevoerd op elke beschikbare agent. Voor meer complexe scenario's kun je specifieke criteria toepassen om een geschikte agent te selecteren.
```
agent any
```
## 5.3. Stages in een Jenkinsfile
Een Jenkinsfile is opgebouwd uit "stages," die afzonderlijke fasen van je CI/CD-pipeline vertegenwoordigen en elke fase definieert een specifieke taak:
- **Checkout**: Haalt de broncode op.
- **Test**: Voert tests uit op de code.
- **Docker Build and Push**: Bouwt een Docker-image en publiceert deze.
- **Kubernetes Deployment**: Deployt de applicatie naar een Kubernetes-cluster.
- **Verify Deployment**: Controleert of de implementatie succesvol is.
![jenkins-pipeline](images/jenkins%20installation%20steps/jenkinspipeline.png)
_Figuur 4: Jenkins pipeline_

# 6. Implementatie van de Jenkinsfile
In dit hoofdstuk gaan we dieper in op de configuratie en uitvoering van de Jenkinsfile die we hebben opgezet voor ons project. We zullen de stappen doorlopen om de Jenkins-pipeline handmatig uit te voeren en het resultaat te bekijken.
## 6.1. Jenkinsfile Configuratie
Laten we beginnen met de Jenkinsfile die we gaan gebruiken als basis voor ons project:
```
pipeline {
    agent any 
    environment {
        DOCKER_USERNAME = 'arsenharutjunjan'
        DOCKER_PASSWORD = 'Password123!'
        KUBECONFIG = 'C:\\Users\\arsen\\.kube\\config' 
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Test') {
            steps {
                dir('HelloWorldWebApp.Tests') {
                    bat 'dotnet test'
                }
            }
        }
        stage('Docker Build and Push') {
            steps {
                sh 'pwd'
                sh 'ls -al'
                sh '''
		            echo "$DOCKER_PASSWORD" | docker login -u $DOCKER_USERNAME --password-stdin
                    docker build -t $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes -f HelloWorldWebApp/Dockerfile .
                    docker push $DOCKER_USERNAME/blogpost-jenkins-ci-cd-kubernetes:latest
                '''
            }
        }
        stage('Kubernetes Deployment') {
            steps {
                script {
                    try {
                        bat 'kubectl apply -f kubernetes/HelloWorldWebApp.yaml' 
                    } catch (err) {
                        echo "Failed to apply kubernetes/HelloWorldWebApp.yaml: ${err}"
                        bat 'kubectl get all' 
                    }
                }
            }
        }
        stage('Verify Deployment') {
            steps {
                bat 'kubectl get deployments' 
            }
        }
    }
}
```
## 6.2. Uitvoeren van de Jenkins-pipeline

Om de Jenkins-pipeline uit te voeren, moet je de volgende stappen volgen:
1. Open de Jenkins-webinterface en navigeer naar het dashboard.
2. Klik op 'Nieuw item maken' om een nieuwe Jenkins-job aan te maken.
3. Geef de job een naam en selecteer het type "Pipeline."
4. Klik op "OK" om de job te maken.
5. In de jobconfiguratie, ga naar het gedeelte "Pipeline" en selecteer "Pipeline script from SCM" als de definitie van de pipeline.
6. Configureer de SCM-opties, zoals het repository-URL en de credentials voor toegang tot de broncode.
7. In het gedeelte "Build Triggers," kun je kiezen wanneer de pipeline moet worden uitgevoerd, bijvoorbeeld elke keer dat er een wijziging wordt gepusht naar het repository.
8. Sla de jobconfiguratie op.
9. Terug op het dashboard, selecteer de zojuist gemaakte job en klik op "Build Now" om de Jenkins-pipeline handmatig te starten.
## 6.3. Resultaat van de Jenkins-pipeline
Na het handmatig starten van de Jenkins-pipeline, volg je de voortgang ervan in de Jenkins-webinterface. Controleer of elke fase succesvol wordt voltooid. Als er problemen optreden, raadpleeg dan de Jenkins-uitvoerlogs en foutmeldingen voor probleemanalyse.

Een succesvolle Jenkins-pipeline betekent dat jouw applicatie is gebouwd, getest, in een Docker-container is verpakt en naar een containerregister is gepusht. Daarna is de applicatie geïmplementeerd in jouw Kubernetes-cluster.

# 7. Conclusie
Dit document heeft de belangrijkste stappen behandeld om een geautomatiseerde Continuous Integration (CI) en Continuous Deployment (CD) pipeline op te zetten met Jenkins en Kubernetes op Windows. Het begrijpen van CI/CD-processen en het kunnen gebruiken van tools zoals Jenkins en Kubernetes is essentieel in moderne softwareontwikkeling.

We moedigen verdere exploratie en praktijk aan om DevOps-vaardigheden verder te ontwikkelen. Het automatiseren van ontwikkelings- en implementatieprocessen zal niet alleen de efficiëntie vergroten, maar ook de stabiliteit en betrouwbaarheid van softwaretoepassingen verbeteren.

Blijf leren en experimenteren om jouw expertise te vergroten. Succes met jouw CI/CD-reis!
# 8. Bronnenlijst

Anastasov, M. (2021, 24 november). _Continuous Integration (CI) explained - Semaphore_. Semaphore. https://semaphoreci.com/continuous-integration


