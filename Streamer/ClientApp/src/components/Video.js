import React from 'react';
import { VideoPlayer } from './VideoPlayer';

export class Video extends React.Component {

    constructor(props) {
        super(props);            
      }    
 
    render() {
        const videoJsOptions = {
            autoplay: true,
            controls: true,
            sources: [{
                src: this.props.url,
                type: 'application/x-mpegURL'
            }]
        }

        return (
            <div className="video">
                <p>{this.props.name}</p>
            
                <VideoPlayer {...videoJsOptions} />
          
            </div>
        )
    }
}