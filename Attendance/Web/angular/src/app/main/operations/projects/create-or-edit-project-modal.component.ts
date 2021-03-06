﻿import { TreeNode } from 'primeng/api';
import { OrganizationUnitsHorizontalTreeModalComponent } from './../../../admin/shared/organization-horizontal-tree-modal.component';
import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { ProjectsServiceProxy, CreateOrEditProjectDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { ProjectUserLookupTableModalComponent } from './project-user-lookup-table-modal.component';
import { ProjectLocationLookupTableModalComponent } from './project-location-lookup-table-modal.component';
import { ProjectOrganizationUnitLookupTableModalComponent } from './project-organizationUnit-lookup-table-modal.component';

@Component({
    selector: 'createOrEditProjectModal',
    templateUrl: './create-or-edit-project-modal.component.html'
})
export class CreateOrEditProjectModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('projectUserLookupTableModal', { static: true }) projectUserLookupTableModal: ProjectUserLookupTableModalComponent;
    @ViewChild('projectLocationLookupTableModal', { static: true }) projectLocationLookupTableModal: ProjectLocationLookupTableModalComponent;
    @ViewChild('projectOrganizationUnitLookupTableModal', { static: true }) projectOrganizationUnitLookupTableModal: ProjectOrganizationUnitLookupTableModalComponent;
    @ViewChild('organizationUnitsHorizontalTreeModal', { static: true }) organizationUnitsHorizontalTreeModal: OrganizationUnitsHorizontalTreeModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    project: CreateOrEditProjectDto = new CreateOrEditProjectDto();

    userName = '';
    locationTitleEn = '';
    organizationUnitDisplayName = '';
    selectedNode: TreeNode;

    constructor(
        injector: Injector,
        private _projectsServiceProxy: ProjectsServiceProxy
    ) {
        super(injector);
    }

    show(projectId?: number): void {

        if (!projectId) {
            this.project = new CreateOrEditProjectDto();
            this.project.id = projectId;
            this.userName = '';
            this.locationTitleEn = '';
            this.organizationUnitDisplayName = '';

            this.active = true;
            this.modal.show();
        } else {
            this._projectsServiceProxy.getProjectForEdit(projectId).subscribe(result => {
                this.project = result.project;

                this.userName = result.userName;
                this.locationTitleEn = result.locationTitleEn;
                this.organizationUnitDisplayName = result.organizationUnitDisplayName;

                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
            this.saving = true;


            this._projectsServiceProxy.createOrEdit(this.project)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }

    openSelectUserModal() {
        this.projectUserLookupTableModal.id = this.project.managerId;
        this.projectUserLookupTableModal.displayName = this.userName;
        this.projectUserLookupTableModal.show();
    }
    openSelectLocationModal() {
        this.projectLocationLookupTableModal.id = this.project.locationId;
        this.projectLocationLookupTableModal.displayName = this.locationTitleEn;
        this.projectLocationLookupTableModal.show();
    }
    openSelectOrganizationUnitModal() {
        // this.projectOrganizationUnitLookupTableModal.id = this.project.organizationUnitId;
        // this.projectOrganizationUnitLookupTableModal.displayName = this.organizationUnitDisplayName;
        // this.projectOrganizationUnitLookupTableModal.show();

            this.organizationUnitsHorizontalTreeModal.show();
    }

    ouSelected(event: any): void {
        debugger
        this.project.organizationUnitId = event.id;
        this.organizationUnitDisplayName = event.displayName;
        //console.log(event);
    }

    setManagerIdNull() {
        this.project.managerId = null;
        this.userName = '';
    }
    setLocationIdNull() {
        this.project.locationId = null;
        this.locationTitleEn = '';
    }
    setOrganizationUnitIdNull() {
        this.project.organizationUnitId = null;
        this.organizationUnitDisplayName = '';
    }


    getNewManagerId() {
        this.project.managerId = this.projectUserLookupTableModal.id;
        this.userName = this.projectUserLookupTableModal.displayName;
    }
    getNewLocationId() {
        this.project.locationId = this.projectLocationLookupTableModal.id;
        this.locationTitleEn = this.projectLocationLookupTableModal.displayName;
    }
    getNewOrganizationUnitId() {
        this.project.organizationUnitId = this.projectOrganizationUnitLookupTableModal.id;
        this.organizationUnitDisplayName = this.projectOrganizationUnitLookupTableModal.displayName;
    }


    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
