﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.GroupTraining;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/groupTraining")]
    [Produces("application/json")]
    public class GroupTrainingController
    {
        private readonly IGroupTrainingRepository groupTrainingRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public GroupTrainingController(IGroupTrainingRepository groupTrainingRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.groupTrainingRepository = groupTrainingRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<List<GroupTrainingDto>>> GetGroupTrainings()
        {
            var groupTrainings = await groupTrainingRepository.GetGroupTrainingsAsync();

            if(groupTrainings == null || groupTrainings.Count == 0)
            {
                return new NoContentResult();
            }

            var groupTrainingDtos = mapper.Map<List<GroupTrainingDto>>(groupTrainings);

            for(int i = 0; i< groupTrainings.Count; i++)
            {

            }

            return new OkObjectResult(mapper.Map<List<GroupTrainingDto>>(groupTrainings));
        }
        [HttpGet("{groupTrainingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<GroupTrainingDto>> GetGroupTrainingById(Guid groupTrainingId)
        {
            var groupTraining = await groupTrainingRepository.GetGroupTrainingByIdAsync(groupTrainingId);

            if(groupTraining == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(mapper.Map<GroupTrainingDto>(groupTraining));
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<ActionResult<GroupTrainingDto>> CreateGroupTraining(GroupTrainingCreateDto groupTraining)
        {
            try
            {
                var newGroupTraining = await groupTrainingRepository.CreateGroupTrainingAsync(mapper.Map<GroupTraining>(groupTraining));
                await groupTrainingRepository.SaveChangesAsync();

                string link = linkGenerator.GetPathByAction("GetGroupTrainingById", "GroupTraining", new { groupTrainingId = newGroupTraining.GroupTrainingId });

                return new CreatedResult(link, mapper.Map<GroupTrainingDto>(newGroupTraining));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{groupTrainingTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> DeleteGroupTraining(Guid groupTrainingId)
        {
            var groupTraining = await groupTrainingRepository.GetGroupTrainingByIdAsync(groupTrainingId);
            if(groupTraining == null)
            {
                return new NotFoundResult();
            }

            try
            {
                await groupTrainingRepository.DeleteGroupTrainingByIdAsync(groupTrainingId);
                await groupTrainingRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<ActionResult<GroupTrainingDto>> UpdateGroupTraining(GroupTrainingUpdateDto groupTrainingUpdate)
        {
            var oldGroupTraining = await groupTrainingRepository.GetGroupTrainingByIdAsync(groupTrainingUpdate.GroupTrainingId);
            if(oldGroupTraining == null)
            {
                return new NotFoundResult();
            }
            try
            {
                mapper.Map(groupTrainingUpdate, oldGroupTraining);
                groupTrainingRepository.SaveChangesAsync();

                return new OkObjectResult(mapper.Map<GroupTrainingDto>(oldGroupTraining));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
