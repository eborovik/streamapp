import React, { useState } from 'react';
import { ButtonDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { startRecording, stopRecording, deleteStream } from "../actions/Videos";

const LiveVideoOptions = (props) => {
    props = props
    const [dropdownOpen, setOpen] = useState(false);

    const toggle = () => setOpen(!dropdownOpen);

    const record = (props) => {
        startRecording(props.streamId)          
    }

    return (
        <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '10px' }}>
            { props.isRecording ? <RecState /> : <div/> }
            <ButtonDropdown isOpen={dropdownOpen} toggle={toggle}>
                <DropdownToggle caret size="sm">
                    Options
                </DropdownToggle>
                <DropdownMenu>
                    <DropdownItem onClick={() => record(props)}>Start recording</DropdownItem>                
                    <DropdownItem onClick={() => stopRecording(props.streamId)}>Stop recording</DropdownItem> 
                    <DropdownItem onClick={() => deleteStream(props.streamId)}>Delete</DropdownItem>                
                </DropdownMenu>
            </ButtonDropdown>            
        </div>        
    );
}

const RecState = () => (
    <span style={{ fontSize: '14px', color: 'red'}}>&#128308; Recording</span>
  )
  

export default LiveVideoOptions;