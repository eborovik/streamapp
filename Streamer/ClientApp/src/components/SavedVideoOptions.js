import React, { useState } from 'react';
import { ButtonDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

const SavedVideoOptions = (props) => {
    props = props
    const [dropdownOpen, setOpen] = useState(false);

    const toggle = () => setOpen(!dropdownOpen);    

    return (
        <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
        <ButtonDropdown isOpen={dropdownOpen} toggle={toggle} >
            <DropdownToggle caret size="sm">
                Options
           </DropdownToggle>
            <DropdownMenu>
                <DropdownItem onClick={() => console.log(props)}>Edit</DropdownItem>
                <DropdownItem>Delete</DropdownItem>

            </DropdownMenu>
        </ButtonDropdown>
        </div>        
    );
}

export default SavedVideoOptions;
