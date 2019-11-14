import { NgModule } from '@angular/core';

import { AzureHttpClient } from './services/azureHttpClient';
import { AzureToolkitService } from './services/azureToolkit.service';
import { CognitiveService } from './services/cognitive.service';
import { UserService } from './services/user.service';

@NgModule({
    providers: [AzureHttpClient, AzureToolkitService, CognitiveService, UserService]
})
export class CommonModule { }
